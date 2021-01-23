    namespace ProjectB 
    {
        public partial class App : Application 
        {
            ...
           
            // this public property exposes an instance of ProjectA.App
            public ProjectA.App TheOtherApp ...
            ...
        }
    }
