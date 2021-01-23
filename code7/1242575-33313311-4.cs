    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace Samples
    {
    	public class DapperResultSet : IXmlSerializable
    	{
    		static readonly Type TableType;
    		static readonly Type RowType;
    		static readonly Func<object, string[]> GetFieldNames;
    		static readonly Func<object, object[]> GetFieldValues;
    		static readonly Func<string[], object> CreateTable;
    		static readonly Func<object, object[], object> CreateRow;
    		static DapperResultSet()
    		{
    			TableType = typeof(Dapper.SqlMapper).GetNestedType("DapperTable", BindingFlags.NonPublic);
    			RowType = typeof(Dapper.SqlMapper).GetNestedType("DapperRow", BindingFlags.NonPublic);
    			// string[] GetFieldNames(object row)
    			{
    				var row = Expression.Parameter(typeof(object), "row");
    				var expr = Expression.Lambda<Func<object, string[]>>(
    					Expression.Field(Expression.Field(Expression.Convert(row, RowType), "table"), "fieldNames"),
    					row);
    				GetFieldNames = expr.Compile();
    			}
    			// object[] GetFieldValues(object row)
    			{
    				var row = Expression.Parameter(typeof(object), "row");
    				var expr = Expression.Lambda<Func<object, object[]>>(
    					Expression.Field(Expression.Convert(row, RowType), "values"),
    					row);
    				GetFieldValues = expr.Compile();
    			}
    			// object CreateTable(string[] fieldNames)
    			{
    				var fieldNames = Expression.Parameter(typeof(string[]), "fieldNames");
    				var expr = Expression.Lambda<Func<string[], object>>(
    					Expression.New(TableType.GetConstructor(new[] { typeof(string[]) }), fieldNames),
    					fieldNames);
    				CreateTable = expr.Compile();
    			}
    			// object CreateRow(object table, object[] values)
    			{
    				var table = Expression.Parameter(typeof(object), "table");
    				var values = Expression.Parameter(typeof(object[]), "values");
    				var expr = Expression.Lambda<Func<object, object[], object>>(
    					Expression.New(RowType.GetConstructor(new[] { TableType, typeof(object[]) }),
    						Expression.Convert(table, TableType), values),
    					table, values);
    				CreateRow = expr.Compile();
    			}
    		}
    		static readonly dynamic[] emptyItems = new dynamic[0];
    		public IReadOnlyList<dynamic> Items { get; private set; }
    		public DapperResultSet()
    		{
    			Items = emptyItems;
    		}
    		public DapperResultSet(IEnumerable<dynamic> source)
    		{
    			if (source == null) throw new ArgumentNullException("source");
    			Items = source as IReadOnlyList<dynamic> ?? new List<dynamic>(source);
    		}
    		XmlSchema IXmlSerializable.GetSchema() { return null; }
    		void IXmlSerializable.WriteXml(XmlWriter writer)
    		{
    			if (Items.Count == 0) return;
    			// Determine field names and types
    			var fieldNames = GetFieldNames((object)Items[0]);
    			var fieldTypes = new TypeCode[fieldNames.Length];
    			for (int count = 0, i = 0; i < Items.Count; i++)
    			{
    				var values = GetFieldValues((object)Items[i]);
    				for (int c = 0; c < fieldTypes.Length; c++)
    				{
    					if (fieldTypes[i] == TypeCode.Empty && values[c] != null)
    					{
    						fieldTypes[i] = Type.GetTypeCode(values[c].GetType());
    						if (++count >= fieldTypes.Length) break;
    					}
    				}
    			}
    			// Write fields
    			writer.WriteStartElement("Fields");
    			writer.WriteAttributeString("Count", XmlConvert.ToString(fieldNames.Length));
    			for (int i = 0; i < fieldNames.Length; i++)
    			{
    				writer.WriteStartElement("Field");
    				writer.WriteAttributeString("Name", fieldNames[i]);
    				writer.WriteAttributeString("Type", XmlConvert.ToString((int)fieldTypes[i]));
    				writer.WriteEndElement();
    			}
    			writer.WriteEndElement();
    			// Write items
    			writer.WriteStartElement("Items");
    			writer.WriteAttributeString("Count", XmlConvert.ToString(Items.Count));
    			foreach (IDictionary<string, object> item in Items)
    			{
    				writer.WriteStartElement("Item");
    				foreach (var entry in item)
    				{
    					writer.WriteStartAttribute(entry.Key);
    					writer.WriteValue(entry.Value);
    					writer.WriteEndAttribute();
    				}
    				writer.WriteEndElement();
    			}
    			writer.WriteEndElement();
    		}
    		void IXmlSerializable.ReadXml(XmlReader reader)
    		{
    			reader.MoveToContent();
    			bool isEmptyElement = reader.IsEmptyElement;
    			reader.ReadStartElement(); // Container
    			if (isEmptyElement) return;
    			// Read fields
    			int fieldCount = XmlConvert.ToInt32(reader.GetAttribute("Count"));
    			reader.ReadStartElement("Fields");
    			var fieldNames = new string[fieldCount];
    			var fieldTypes = new TypeCode[fieldCount];
    			var fieldIndexByName = new Dictionary<string, int>(fieldCount);
    			for (int c = 0; c < fieldCount; c++)
    			{
    				fieldNames[c] = reader.GetAttribute("Name");
    				fieldTypes[c] = (TypeCode)XmlConvert.ToInt32(reader.GetAttribute("Type"));
    				fieldIndexByName.Add(fieldNames[c], c);
    				reader.ReadStartElement("Field");
    			}
    			reader.ReadEndElement();
    			// Read items
    			int itemCount = XmlConvert.ToInt32(reader.GetAttribute("Count"));
    			reader.ReadStartElement("Items");
    			var items = new List<dynamic>(itemCount);
    			var table = CreateTable(fieldNames);
    			for (int i = 0; i < itemCount; i++)
    			{
    				var values = new object[fieldCount];
    				if (reader.MoveToFirstAttribute())
    				{
    					do
    					{
    						var fieldName = reader.Name;
    						var fieldIndex = fieldIndexByName[fieldName];
    						values[fieldIndex] = Convert.ChangeType(reader.Value, fieldTypes[fieldIndex], CultureInfo.InvariantCulture);
    					}
    					while (reader.MoveToNextAttribute());
    				}
    				reader.ReadStartElement("Item");
    				var item = CreateRow(table, values);
    				items.Add(item);
    			}
    			reader.ReadEndElement(); // Items
    			reader.ReadEndElement(); // Container
    			Items = items;
    		}
    	}
    }
