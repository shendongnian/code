    // Create a formatted Paragraph
    Paragraph para = new Paragraph();
    para.FontSize = 25;
    para.FontWeight = FontWeights.Bold;
    para.Inlines.Add(new Run("Text of paragraph."));
    
    // Clone all Inlines
    List<Inline> clonedInlines = new List<Inline>();
    foreach (Inline inline in para.Inlines)
    {
    	Inline clonedInline = ElementClone<Inline>(inline);
    	clonedInlines.Add(clonedInline);
    }
    
    // Get all Paragraph properties with a set value
    List<DependencyProperty> depProps = DepPropsGet(para, PropertyFilterOptions.SetValues);
    
    // Apply the Paragraph values to each Inline
    foreach (DependencyProperty depProp in depProps)
    {
    	object propValue = para.GetValue(depProp);
    
    	foreach (Inline clonedInline in clonedInlines)
    	{
    		// Can the Inline have the value?
    		if (depProp.OwnerType.IsAssignableFrom(typeof(Inline)))
    		{
    			// Apply the Paragraph value
    			clonedInline.SetValue(depProp, propValue);
    		}
    	}
    }
    
    // Create a TextBlock with the same properties as the Paragraph
    TextBlock textBlock = new TextBlock();
    textBlock.Inlines.AddRange(clonedInlines);
    /// <summary>
    /// Cloner.
    /// </summary>
    public static T ElementClone<T>(T element)
    {
    	// Element to Stream
    	MemoryStream memStream = new MemoryStream();
    	XamlWriter.Save(element, memStream);
    
    	// Cloned element from Stream
    	object clonedElement = null;
    	if (memStream.CanRead)
    	{
    		memStream.Seek(0, SeekOrigin.Begin);
    		clonedElement = XamlReader.Load(memStream);
    		memStream.Close();
    	}
    	return (T)clonedElement;
    }
    
    /// <summary>
    /// Property-Getter.
    /// </summary>
    public static List<DependencyProperty> DepPropsGet(DependencyObject depObj, PropertyFilterOptions filter)
    {
    	List<DependencyProperty> result = new List<DependencyProperty>();
    
    	foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(depObj, new Attribute[] { new PropertyFilterAttribute(filter) }))
    	{
    		DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(pd);
    
    		if (dpd != null)
    		{
    			result.Add(dpd.DependencyProperty);
    		}
    	}
    
    	return result;
    }
