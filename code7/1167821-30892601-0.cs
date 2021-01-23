    internal static class ListViewBehaviors
    {
        public static readonly DependencyProperty ContentTransformProperty = DependencyProperty.RegisterAttached("ContentTransform", typeof(Transform), typeof(ListViewBehaviors),
            new PropertyMetadata((Transform)null, OnContentTransformChanged));
        public static Transform GetContentTransform(ListView obj)
        {
            return (Transform)obj.GetValue(ContentTransformProperty);
        }
        public static void SetContentTransform(ListView obj, Transform value)
        {
            obj.SetValue(ContentTransformProperty, value);
        }
        private static void OnContentTransformChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ListView view = obj as ListView;
            if (view != null)
            {
                if (view.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                {
                    EventHandler handler = null;
                    handler = (s, a) => ListView_ItemContainerGenerator_StatusChanged(view, handler);
                    view.ItemContainerGenerator.StatusChanged += handler;
                }
                else
                {
                    UpdateTransform(view);
                }
            }
        }
        private static void ListView_ItemContainerGenerator_StatusChanged(ListView view, EventHandler handler)
        {
            if (view.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                view.ItemContainerGenerator.StatusChanged -= handler;
                UpdateTransform(view);
            }
        }
        private static void UpdateTransform(ListView view)
        {
            EventHandler handler = null;
            handler = (s, e) => LayoutUpdated(view, handler);
            view.LayoutUpdated += handler;
        }
        private static void LayoutUpdated(ListView view, EventHandler handler)
        {
            view.LayoutUpdated -= handler;
            ScrollViewer scroller = VisualTreeUtility.FindDescendant<ScrollViewer>(view);
            if (scroller != null)
            {
                Transform transform = GetContentTransform(view);
                FrameworkElement header = VisualTreeUtility.FindDescendant<ScrollViewer>(scroller);
                if (header != null)
                {
                    header.LayoutTransform = transform;
                }
                FrameworkElement content = scroller.Template.FindName("PART_ScrollContentPresenter", scroller) as FrameworkElement;
                if (content != null)
                {
                    content.LayoutTransform = transform;
                }
            }
        }
    }
