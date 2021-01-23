    private void AddAdorner(InlineUIContainer container)
    {
        if (container != null)
        {
            var image = container.Child;
            if (image != null)
            {
                var al = AdornerLayer.GetAdornerLayer(image);
                if (al != null)
                {
                    var currentAdorners = al.GetAdorners(image);
                    if (currentAdorners != null)
                    {
                        foreach (var adorner in currentAdorners)
                        {
                            al.Remove(adorner);
                        }
                    }
                    al.Add(new ResizingAdorner(image));
                }
            }
        }
    }
