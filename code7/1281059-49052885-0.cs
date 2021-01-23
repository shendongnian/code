    public class ScrollBarDisabledRenderer : ScrollViewRenderer    
    {   
         protected override void OnElementChanged(VisualElementChangedEventArgs e)
         {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            e.NewElement.PropertyChanged += OnElementPropertyChanged;
          }
        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ShowsHorizontalScrollIndicator = false;
            ShowsVerticalScrollIndicator = false;
        }
    }
