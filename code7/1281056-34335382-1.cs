    public class ScrollViewExRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
    
            if (e.OldElement == null || this.Element == null)
                return;
    
            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
    
            e.NewElement.PropertyChanged += OnElementPropertyChanged;
    
        }
    
        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ChildCount > 0)
            {
                GetChildAt(0).HorizontalScrollBarEnabled = false;
                GetChildAt(0).VerticalScrollBarEnabled = false;
            }
        }
    } 
