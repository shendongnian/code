    public class CustomControl : Control  
    { 
          public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof (IList), typeof (CustomControl), new PropertyMetadata(new List<string>())); 
 
      public IList Items 
      { 
           get { return (IList)GetValue(ItemsProperty); } 
           set { SetValue(ItemsProperty, value); }
      } 
 
      public CustomControl() 
      {
            Items = new List<string>(); 
      } 
     }
