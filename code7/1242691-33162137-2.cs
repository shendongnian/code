    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ControllerDemonstrator
    {
        public class Communicator
        {
            public event EventHandler DataLoaded;
    
            public Communicator(Controller controller)
            {
                controller.FormTestConnection += controller_FormTestConnection;
            }
    
            private void controller_FormTestConnection(object sender, EventArgs e)
            {
                //  put your code that does the connection here
                //  -------------------------------------------
                if (null != DataLoaded)
                {
                    DataLoaded(this, new EventArgs());
                }
            }
        }
    }
