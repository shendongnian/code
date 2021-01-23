    namespace Your.Namespace
    {
        // use some nice name for your model
        public class BoxStatusModel  
        {
           public int BoxID { get; set; }
           public string CurrentStatus { get; set; }
           public string Color
           {
              get
              {
                 switch(CurrentStatus)
                 {
                    case "Ok":
                      return "Green";
                    case "Warning":
                       return "Yellow";
                    case "Error":
                       return "Red";
                    default:
                        return "";
                 }
              }
           }
        }
    } 
