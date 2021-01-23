    public class MyCanvas : Canvas
    {
        public static readonly DependencyProperty StopDropPropagationProperty = DependencyProperty.Register(
            "StopDropPropagation", typeof (bool), typeof (MyCanvas), new PropertyMetadata(default(bool)));
    
        public bool StopDropPropagation
        {
            get { return (bool) GetValue(StopDropPropagationProperty); }
            set { SetValue(StopDropPropagationProperty, value); }
        }
    
        protected override void OnDrop(DragEventArgs e)
        {
            Children.Add(new TextBlock
            {
                Text = "Dropped here"
            });
    
            e.Handled = StopDropPropagation;
        }
    }
