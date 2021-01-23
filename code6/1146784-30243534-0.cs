    public partial class MainForm : Form, IMenuContainer
    {
        public MenuStrip Menu 
        {
            get 
            {
               return this.mnsMainApp; 
            }
        }
        
        private void MainForm_Load(Object sender, EventArgs e)
        {
            ILifetimeScope scope = ... // get the Autofac scope
            foreach(IMenuBuilder menuBuilder in scope.Resolve<IEnumerable<IMenuBuilder>())
            {
                menuBuilder.BuildMenu(this); 
            }
        }
    }
