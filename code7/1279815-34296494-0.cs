    public class ChildForm()
    {
        ... existing form code ...
        public event EventHandler<EventArgs> DisconnectClicked;
    
        protected void Disconnect_Clicked(object sender, EventArgs e)
        {
           if(DisconnectClicked != null)
           {
               DisconnectClicked(this, new EventArgs());
           }
        }
    }
    public class ParentForm()
    {
        public void ShowChildForm()
        {
            ... existing code to show child ...
            child.DisconnectClicked += (sender, args) => 
            {  
                // call existing code in parent form that disconnects the port
                DisconnectPort() 
            };
           child.Show();
        }
    }
