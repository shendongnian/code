	private void ChangeTypeProperties(Type modifiedType, params string[] propertyNames)
	{
        // Get the current TypeDescriptionProvider
		var curProvider = TypeDescriptor.GetProvider(modifiedType);
        // Create a replacement provider, pass in the parent, this is important
		var replaceProvider = new PropertyOverridingTypeDescriptionProvider(curProvider,
            // This the predicate that says wether a `PropertyDescriptor` should be changed
            // Here we are changing only the System.Drawing.Image properties,
            // either those whose name we pass in, or all if we pass none
			pd =>
				typeof (System.Drawing.Image).IsAssignableFrom(pd.PropertyType) &&
				(propertyNames.Length == 0 || propertyNames.Contains(pd.Name)),
            // This our "replacer" function. It'll get the source PropertyDescriptor and the object type.
            // You could use pd.ComponentType for the object type, but I've
            // found it to fail under some circumstances, so I just pass it
            // along
			(pd, t) =>
			{
                // Get original attributes except the ones we want to change
				var atts = pd.Attributes.OfType<Attribute>().Where(x => x.GetType() != typeof (EditorAttribute)).ToList();
                // Add our own attributes
				atts.Add(new EditorAttribute(typeof (MyOwnEditor), typeof (System.Drawing.Design.UITypeEditor)));
                // Create the new PropertyDescriptor
				return TypeDescriptor.CreateProperty(t, pd, atts.ToArray());
			}
		);
        // Finally we replace the TypeDescriptionProvider
		TypeDescriptor.AddProvider(replaceProvider, modifiedType);
	}
