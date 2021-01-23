    public class MyItemWrapper
    {
       public MyItemWrapper(MyItem item)
       {
         Info=item;
         IsVisible = true; 
       }
       public MyItem Info {get; set;}
       public bool IsVisible {get; set;}
    }
