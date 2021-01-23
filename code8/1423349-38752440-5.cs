    using ArcClientUserInterface;  // This is the second namespace
    using ArcControlClient; // This is the first namespace (all classes set to internal).
    namespace ArcEndUser
    {
        class EndUser
        {
            public EndUser()
            {       
                // The end user can access public classes from the assembly's
                // second namespace, ArcClientUserInterface as seen below.      
                SrvcManagerConsole sMC = new SrvcManagerConsole();
                sMC.DoThis();      
                // Trying to access anything here from the assembly's 
                // first namespace, ArcControlClient will fail.   
                // Now, all the inner workings of the assembly are undetectable.
            }
        }
    }
