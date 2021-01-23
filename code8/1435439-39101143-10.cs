    public class UserControl1Designer : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((UserControl1)this.Control).MyTabControl, "MyTabControl");
        }
        public override void InitializeNewComponent(System.Collections.IDictionary values)
        {
            base.InitializeNewComponent(values);
            AddTab();
            AddTab();
        }
        private void AddTab()
        {
            TabControl tabControl = ((UserControl1)this.Control).MyTabControl;
            var svc = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (svc != null)
            {
                var tab1 = (TabPage)svc.CreateComponent(typeof(TabPage));
                tab1.Text = tab1.Name;
                tab1.UseVisualStyleBackColor = true;
                tabControl.TabPages.Add(tab1);
                var property = TypeDescriptor.GetProperties(tabControl)["Controls"];
                base.RaiseComponentChanging(property);
                base.RaiseComponentChanged(property, null, null);
            }
        }
    }
