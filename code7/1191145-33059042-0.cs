    public partial class ManagedFrom : Form
    {
        // this is the fix. Everytime the form comes up. It tries to register itself.
        //The existing magic will consider its request to register only when the other form is closed or if its the 1st of its type.
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            NotifierService.OnOk += NotifierService_OnOk;
        }
