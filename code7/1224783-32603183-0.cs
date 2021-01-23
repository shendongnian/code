        public class HelperController:Controller{
                public PartialViewResult sidebar(string thisController, string thisAction)
                {
                   string con_action = thisController + "-" + thisAction;
                   ...
                }
            }
