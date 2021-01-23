    private List<BitmapImage> FindImages(C1TextRange selection = null)
    {
        var result = new List<BitmapImage>();
        if (selection == null)
        {
            // Document Contains all elements at the document level.
            foreach (C1TextElement elem in Document)
            {
                FindImagesRecursive(elem, result);
            }
        }
        else
        {
            // Selection contains all (selected) elements -> no need to search recursively
            foreach (C1TextElement elem in selection.ContainedElements)
            {
                if (elem is C1InlineUIContainer)
                {
                    FindImage(elem as C1InlineUIContainer, result);
                }
            }
        }
    	
        return result;
    }
    
    private void FindImagesRecursive(C1TextElement elem, List<BitmapImage> list)
    {
        if (elem is C1Paragraph)
        {
            var para = (C1Paragraph)elem;
            foreach (C1Inline inl in para.Inlines)
            {
                FindImagesRecursive(inl, list);
            }
        }
        else if (elem is C1Span)
        {
            var span = (C1Span)elem;
            foreach (C1Inline child in span.Inlines)
            {
                FindImagesRecursive(child, list);
            }
        }
        else if (elem is C1InlineUIContainer)
        {
            FindImage(elem as C1InlineUIContainer, list);
        }
    }
    
    private void FindImage(C1InlineUIContainer container, List<BitmapImage> list)
    {
    	if (container.Content is BitmapImage)
    	{
    		list.Add(container.Content as BitmapImage);
        }
    }
