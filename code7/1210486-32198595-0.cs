    public static class LinqToVisualTree
    {
        public static IEnumerable<TElement> Ancestors<TElement>(this UIElement element) where  TElement : UIElement
        {
            while (true)
            {
                var parent = VisualTreeHelper.GetParent(element);
                if (parent is TElement) yield return (TElement) parent;
                if (parent == null) break;
            }
        }
    }
