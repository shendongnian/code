     public partial class _Default : Page
        {      
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            private void Log()
            {            
                if (ViewState["prevStatus"] != null && ViewState["currStatus"] != null)
                {
                    prevStatus = (Dictionary<string, ServiceControllerStatus>)ViewState["prevStatus"];
                    currStatus = (Dictionary<string, ServiceControllerStatus>)ViewState["currStatus"];                
                    
                    foreach (var item in currStatus)
                    {
                        ServiceControllerStatus oldStatus;
                        if (prevStatus.TryGetValue(item.Key, out oldStatus) && !(oldStatus == item.Value))
                        {
                            string[] split = item.Key.Split('_');
                            writeToLogFile("The service " + split[0] + " on server " + split[1] + " was changed to " + item.Value + " from another source.");
                        }
                    }                
                }           
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Do stuff
    
                this.Log();
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                // Stop/start service
                var button = (Button)sender;
                string machine = button.CommandArgument;
                string service;
    
                /*Do stuff */
                writeToLogFile("User " + HttpContext.Current.User.Identity.Name + " pressed the " + button.CommandName + " button on server " + machine + " with the services " + checkedBoxes(machine) + " checked.");
            }
    
        }
