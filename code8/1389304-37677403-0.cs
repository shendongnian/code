    public class usercontrol1 :UserControl{
     public static EventHandler<sometype> NewType;
        public usercontrol(){
               NewType +=(o,sometype)=>{
                   //sometype has the content here.
               }
        }
    }
