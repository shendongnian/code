    using ArcClientUserInterface;  // This is the second namespace
    using ArcControlClient; // This is the first namespace (all classes set to internal).
    namespace ArcEndUser
    {
        class EndUser
        {
            public EndUser()
            {            
                SrvcManagerConsole sMC = new SrvcManagerConsole();
                sMC.DoThis();         
            }
        }
    }
