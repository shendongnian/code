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
    		private static readonly XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
    		private static readonly UTF8Encoding defaultEncoding = new UTF8Encoding(false);
    
    		static XmlSerializers()
    		{
    			xns.Add("", "");
    		}
    
    		private static XmlSerializer GetSerializer(Type type, XmlRootAttribute xmlRoot = null)
    		{
    			return serializers.GetOrAdd(type, t => new XmlSerializer(t, xmlRoot));
    		}
    
    		public static byte[] SerializeToBytes<T>(T obj, bool omitXmlDeclaration = true, string customRootName = null, bool omitNamespaces = true, Encoding encoding = null)
    		{
    			if (ReferenceEquals(null, obj))
    				return null;
    			using (var ms = new MemoryStream())
    			{
    				var xmlSettings = new XmlWriterSettings
    				{
    					OmitXmlDeclaration = omitXmlDeclaration,
    					NewLineHandling = NewLineHandling.Entitize,
    					Indent = true,
    					Encoding = encoding ?? defaultEncoding
    				};
    				using (var xmlWriter = XmlWriter.Create(ms, xmlSettings))
    				{
    					var xmlRootNameAttribute = string.IsNullOrEmpty(customRootName) ? null : new XmlRootAttribute(customRootName);
    					GetSerializer(typeof(T), xmlRootNameAttribute).Serialize(xmlWriter, obj, omitNamespaces ? xns : null);
    					return ms.ToArray();
    				}
    			}
    		}
    
    		public static string Serialize<T>(T obj, bool omitNamespaces = true, Encoding encoding = null, bool omitXmlDeclaration = true, string customRootName = null)
    		{
    			var bytes = SerializeToBytes(obj, omitXmlDeclaration, customRootName, omitNamespaces, encoding);
    			return (encoding ?? defaultEncoding).GetString(bytes);
    		}
    
    		public static string SafeSerialize<T>(T obj, bool omitNamespaces = true, Encoding encoding = null, bool omitXmlDeclaration = true, string customRootName = null)
    		{
    			try
    			{
    				return Serialize(obj, omitNamespaces, encoding, omitXmlDeclaration, customRootName);
    			}
    			catch (Exception e)
    			{
    				// log error here
    			}
    			return null;
    		}
    
    		public static T SafeDeserialize<T>(byte[] serializedData, Encoding encoding = null, bool silentMode = false)
    			where T : class 
    		{
    			try
    			{
    				return DeserializeFromBytes<T>(serializedData, encoding);
    			}
    			catch (Exception e)
    			{
    				if (!silentMode)
    				{
    					// log error here
    				}
    			}
    			return null;
    		}
    
    		public static T SafeDeserialize<T>(string serializedData, Encoding encoding = null, bool silentMode = false)
    			where T : class
    		{
    			try
    			{
    				return Deserialize<T>(serializedData, encoding);
    			}
    			catch (Exception e)
    			{
    				if (!silentMode)
    				{
    					// log error here
    				}
    			}
    			return null;
    		}
    
    		public static T DeserializeFromBytes<T>(byte[] serializedData, Encoding encoding = null) where T : class
    		{
    			using (var sr = new StreamReader(new MemoryStream(serializedData), encoding ?? defaultEncoding))
    			using (var xmlReader = XmlReader.Create(sr))
    				return (T) GetSerializer(typeof(T)).Deserialize(xmlReader);
    		}
    
    		public static T Deserialize<T>(string stringData, Encoding encoding = null) where T : class
    		{
    			var bytes = (encoding ?? defaultEncoding).GetBytes(stringData);
    			return DeserializeFromBytes<T>(bytes, encoding);
    		}
    	}
    }
