    //Use a namespace alias
       using Other = KSWeb.KSS;
        
        namespace KSWeb
        {
            partial class NewCK : Base
            {
              //You can now use Other as below
               Other.Method();
            }
        }
