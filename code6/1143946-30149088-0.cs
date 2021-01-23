	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.Text;
	using System.Xml.Serialization;
	namespace WcfService1
	{
		[XmlRoot("dictionary")]
		public class SerializableDictionary<TKey, TValue>
			: Dictionary<TKey, TValue>, IXmlSerializable
		{
			#region IXmlSerializable Members
			public System.Xml.Schema.XmlSchema GetSchema()
			{
				return null;
			}
			public void ReadXml(System.Xml.XmlReader reader)
			{
				XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
				XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
				bool wasEmpty = reader.IsEmptyElement;
				reader.Read();
				if (wasEmpty)
					return;
				while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
				{
					reader.ReadStartElement("item");
					reader.ReadStartElement("key");
					TKey key = (TKey)keySerializer.Deserialize(reader);
					reader.ReadEndElement();
					reader.ReadStartElement("value");
					TValue value = (TValue)valueSerializer.Deserialize(reader);
					reader.ReadEndElement();
					this.Add(key, value);
					reader.ReadEndElement();
					reader.MoveToContent();
				}
				reader.ReadEndElement();
			}
			public void WriteXml(System.Xml.XmlWriter writer)
			{
				XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
				XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
				foreach (TKey key in this.Keys)
				{
					writer.WriteStartElement("item");
					writer.WriteStartElement("key");
					keySerializer.Serialize(writer, key);
					writer.WriteEndElement();
					writer.WriteStartElement("value");
					TValue value = this[key];
					valueSerializer.Serialize(writer, value);
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
			}
			#endregion
		}
		[ServiceContract]
		public interface IService1
		{
			[OperationContract]
			string calculateCost(SerializableDictionary<String, String[]> to);        
		}
		public class Service1 : IService1
		{
			public string calculateCost(SerializableDictionary<String, String[]> to)
			{
				StringBuilder output = new StringBuilder();
				foreach (KeyValuePair<String, String[]> item in to)
				{
					output.AppendLine(string.Format("{0} => {1}", item.Key, String.Join(",", item.Value)));
				}
				return output.ToString();
			}      
		}
	}
