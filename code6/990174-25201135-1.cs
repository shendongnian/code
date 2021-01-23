    public abstract class EquatableObject<TObject>: IEquatable<TObject>
		where TObject : class	
	{
		protected EquatableObject()
		{			
		}
		public override int GetHashCode()
		{
			IEnumerable<FieldInfo> fields = GetFields();
			int startValue = 17;
			int multiplier = 59;
			int hashCode = startValue;
			foreach (FieldInfo field in fields)
			{
				object value = field.GetValue(this);
				if (value != null)
					hashCode = hashCode * multiplier + value.GetHashCode();
			}
			return hashCode;
		}
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			TObject other = obj as TObject;
			return Equals(other);
		}
		public virtual bool Equals(TObject other)
		{
			if (other == null)
				return false;
			Type t = GetType();
			Type otherType = other.GetType();
			if (t != otherType)
				return false;
			FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			foreach (FieldInfo field in fields)
			{
				object value1 = field.GetValue(other);
				object value2 = field.GetValue(this);
				if (value1 == null)
				{
					if (value2 != null)
						return false;
				}
				else if (!value1.Equals(value2))
					return false;
			}
			return true;
		}
		private IEnumerable<FieldInfo> GetFields()
		{
			Type t = GetType();
			List<FieldInfo> fields = new List<FieldInfo>();
			while (t != typeof(object))
			{
				fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
				t = t.BaseType;
			}
			return fields;
		}
	}
