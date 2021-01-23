     public class MyRect : DependencyObject,INotifyPropertyChanged
    {
        public MyRect()
        {            
            this.Rect = new Rect(0d, 0d, (double)Width, (double)Height);      
        }      
        private Rect rect;
        public Rect Rect
        {
            get { return rect; }
            set 
            {
                rect = value;
                RaiseChange("Rect");
            }
        }
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(MyRect), new UIPropertyMetadata(1d, OnHeightChanged));
        public static void OnHeightChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var MyRect = (dp as MyRect);
                var hight = Convert.ToDouble(e.NewValue);
                MyRect.Rect = new Rect(0d, 0d, MyRect.Rect.Width, hight);                
            }
        }
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(MyRect), new UIPropertyMetadata(1d, OnWidthChanged));
        public static void OnWidthChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var MyRect = (dp as MyRect);
                var width = Convert.ToDouble(e.NewValue);
                MyRect.Rect = new Rect(0d, 0d, width, MyRect.Rect.Height);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }  
