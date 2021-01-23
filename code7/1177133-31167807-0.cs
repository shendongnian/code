    public class CustomControl : Control
    {
     public static readonly DependencyProperty ItemsProperty = 
                 DependencyProperty.Register("Items", typeof(IEnumerable<string>), typeof (CustomControl), new PropertyMetadata(new List<string>())); 
 
         public IEnumerable<string> Items 
         { 
             get { return (IEnumerable<string>) GetValue(ItemsProperty); } 
             set { SetValue(ItemsProperty, value); } 
         } 
    }
