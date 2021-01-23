    public class MyUserControl2Designer : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((UserControl2)this.Control).MyTabControl, "MyTabControl");
            this.EnableDesignMode(((UserControl2)this.Control).T1, "T1");
        }
    }
