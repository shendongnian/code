    public class YourControl{  
    
         public Object MyUsersContent
         {
             get { return (Object)GetValue(MyUsersContentProperty); }
             set { SetValue(MyUsersContentProperty, value); }
         }
        
         public static readonly DependencyProperty MyUsersContentProperty =
                       DependencyProperty.Register("MyUsersContent", 
                           typeof(Object), typeof(YoutControl), new PropertyMetadata());   
     }
