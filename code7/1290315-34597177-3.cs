    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Rikrop.Core.Serialization.Xml
    {
    	public static class XmlSerializers
    	{
    		private static readonly ConcurrentDictionary<Type, XmlSerializer> serializers = new ConcurrentDictionary<Type, XmlSerializer>();
    		private static readonly XmlSerializerNamespaces xnameSpace = new XmlSerializerNamespaces();
    		private static readonly UTF8Encoding defaultEncoding = new UTF8Encoding(false);
    
    		static XmlSerializers()
    		{
    			xnameSpace.Add("", "");
    		}
    
    		private static XmlSerializer GetSerializer(Type type)
    		{
    			return serializers.GetOrAdd(type, t => new XmlSerializer(t));
    		}
    
    		public static byte[] Serialize(object obj, bool omitNamespaces = false, Encoding encoding = null)
    		{
    			if (ReferenceEquals(null, obj))
    				return null;
    			using (var stream = new MemoryStream())
    			{
    				using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { OmitXmlDeclaration = false, Encoding = encoding ?? defaultEncoding, Indent = true}))
    				{
    					GetSerializer(obj.GetType()).Serialize(xmlWriter, obj, omitNamespaces ? xnameSpace : null);
    					return stream.ToArray();
    				}
    			}
    		}
    
    		public static string SerializeToString(object obj, bool omitNamespaces = false, Encoding encoding = null)
    		{
    			var bytes = Serialize(obj, omitNamespaces, encoding);
    			return (encoding ?? defaultEncoding).GetString(bytes);
    		}
    
    		public static TData Deserialize<TData>(byte[] serializedData, Encoding encoding = null) where TData : class
    		{
    			using (var sr = new StreamReader(new MemoryStream(serializedData), encoding ?? defaultEncoding))
    			using (var xmlReader = XmlReader.Create(sr))
    				return (TData)GetSerializer(typeof(TData)).Deserialize(xmlReader);
    		}
    
    		public static TData DeserializeFromString<TData>(string stringData, Encoding encoding = null) where TData : class
    		{
    			var bytes = (encoding ?? defaultEncoding).GetBytes(stringData);
    			return Deserialize<TData>(bytes);
    		}
    	}
    }
