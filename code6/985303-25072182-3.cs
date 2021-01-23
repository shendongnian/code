    public class MyListItem : Control
    {
       //Define the property/event/control logic you want
       static MyListItem ()
       {
         //Remeber this to override the default style
         DefaultStyleKeyProperty.OverrideMetadata(typeof(MyListItem ), new FrameworkPropertyMetadata(typeof(MyListItem )));
       }
    }
