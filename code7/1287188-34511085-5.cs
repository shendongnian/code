		internal class PropertyOverridingTypeDescriptor : CustomTypeDescriptor
		{
			private readonly ICustomTypeDescriptor _parent;
			private readonly PropertyDescriptorCollection _propertyCollection;
			private readonly Type _objectType;
			private readonly Func<PropertyDescriptor, bool> _condition;
			private readonly Func<PropertyDescriptor, Type, PropertyDescriptor> _propertyCreator;
			public PropertyOverridingTypeDescriptor(ICustomTypeDescriptor parent, Type objectType, Func<PropertyDescriptor, bool> condition, Func<PropertyDescriptor, Type, PropertyDescriptor> propertyCreator)
				: base(parent)
			{
				_parent = parent;
				_objectType = objectType;
				_condition = condition;
				_propertyCreator = propertyCreator;
				_propertyCollection = BuildPropertyCollection();
			}
			private PropertyDescriptorCollection BuildPropertyCollection()
			{
				var isChanged = false;
				var parentProperties = _parent.GetProperties();
				var pdl = new PropertyDescriptor[parentProperties.Count];
				var index = 0;
				foreach (var pd in parentProperties.OfType<PropertyDescriptor>())
				{
					var pdReplaced = pd;
					if (_condition(pd))
					{
						pdReplaced = _propertyCreator(pd, _objectType);
					}
					if (!ReferenceEquals(pdReplaced, pd)) isChanged = true;
					pdl[index++] = pdReplaced;
				}
				return !isChanged ? parentProperties : new PropertyDescriptorCollection(pdl);
			}
			public override object GetPropertyOwner(PropertyDescriptor pd)
			{
				var o = base.GetPropertyOwner(pd);
				return o ?? this;
			}
			public override PropertyDescriptorCollection GetProperties()
			{
				return _propertyCollection;
			}
			public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
			{
				return _propertyCollection;
			}
		}
