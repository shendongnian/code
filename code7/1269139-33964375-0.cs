    public class MyAttachClass
    {
        public static readonly DependencyProperty TotalChildCountProperty = DependencyProperty.RegisterAttached("TotalChildCount", typeof(int), typeof(MyAttachClass), 
        new PropertyMetadata(-1, OnTotalChildCountChanged));
    
        public static int GetTotalChildCount(DependencyObject obj)
        {
            return (int)obj.GetValue(TotalChildCountProperty);
        }
    
        public static void SetTotalChildCount(DependencyObject obj, int value)
        {
            obj.SetValue(TotalChildCountProperty, value);
        }
    
        public static void OnTotalChildCountChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                var children = Recursive.GetAllChildren(txt);
                txt.Text = children.Count().ToString();
            }
        }
    }
