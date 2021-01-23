        using System.Windows.Interactivity;
    
        public class MyBehavior : Behavior<ContentControl>
        { 
             public MyBehavior()
             {}
    
             protected override void OnAttached()
             {
                 AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
                 base.OnAttached();
             }
    
             protected override void OnDetaching()
             {
                 AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
             }
    
             void AssociatedObject_MouseDoubleClick(object sender, MouseButtonEventArgs e)
             {
                 // do something
             }
        }
