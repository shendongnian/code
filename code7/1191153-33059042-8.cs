     public partial class ManagedFrom : Form
    {
      
        //start the subscription
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            NotifierService.OnOk += NotifierService_OnOk;
        }
        //stop the subscription
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            NotifierService.OnOk -= NotifierService_OnOk;
        }
