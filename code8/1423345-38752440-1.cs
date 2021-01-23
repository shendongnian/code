    using ControlClient; // referencing the first name space
    // This is the second namespace with public classes.
    namespace ClientUserInterface 
    {
        /// <summary>
        /// SrvcManagerConsole wraps the mngrConsole.
        /// They both implement the IManagerConsole interface.
        /// </summary>
        public class SrvcManagerConsole
        {
            IManagerConsole srvcManager;
            public SrvcManagerConsole()
            {
                // this.srvcManager = srvcManager;
                ClientStarter ccs = new ClientStarter();
                this.srvcManager = ccs.GetSrvcManagerConsole();
            }
            // The DoThis() method of this wrapper class will
            // call the DoThis() method of the object from the 
            // first namespace that implements the same
            // interface. The end user can't see the 
            // srvcManager object.
            public void DoThis()
            {
                srvcManager.DoThis();            
            }
        }
    }
