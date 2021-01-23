		public bool IsMutable
		{
			get { return false; }
		}
		public void SetPropertyValue(object component, int property, object value)
		{
          throw new NotSupportedException("Something goes wrong here");
        }
		public object GetPropertyValue(object component, int property)
		{
          var stringComponent = (string)component;
          maxLengthToRead = Math.Min(2000, stringComponent.Length - property * 2000);
          if (maxLengthToRead <= 0) return string.Empty;
          return stringComponent.Substring(property * 2000, maxLengthToRead);
        }
