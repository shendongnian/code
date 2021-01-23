    public class HelpPlugin : IPlugin, IMenuHandler
    {
        public HelpPlugin(IMenuService service)
        {
            service.AddTopMenu("Help", this);
        }
    
        void IMenuHandler.Handle(MenuClick click)
        {
            MessageBox.Show("Menu button was clicked");
        }
    }
