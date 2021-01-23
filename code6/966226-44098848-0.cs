		public class TabFontConverter : TypeConverter
		{
			public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
			{
				PropertyDescriptorCollection rawResult = TypeDescriptor.GetProperties(value, filter);
				PropertyDescriptor[] arrRawResult = new PropertyDescriptor[rawResult.Count - 1];
				int i = 0;
				int j = 0;
				while (i < rawResult.Count)
				{
					if (rawResult[i].Name != "Name")
					{
						arrRawResult[j] = rawResult[i];
						j++;
					}
					i++;
				}
				PropertyDescriptorCollection filteredResult = new PropertyDescriptorCollection(arrRawResult);
				return filteredResult;
			}
