    public class SomePage : ContentPage
    {
          public static SomePage ThisPage {get; set;}
    
          Label label;
    
          public SomePage()
          {
               ThisPage = this;
               label = new Label();
          }
    
    }
