    using System;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    public class MyCustomToolStrip : ToolStrip
    {
        private IDesignerHost designerHost;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                {
                    var designer = designerHost.GetDesigner(this);
                    if (designer != null)
                    {
                        var actionList = ((ControlDesigner)designer).ActionLists[0];
                        designer.Verbs.Add(new DesignerVerb("My Custom Verb", MyCustomVerb));
                    }
                }
            }
        }
        private void MyCustomVerb(object sender, EventArgs e)
        {
            MessageBox.Show("My Custom Verb added!");
        }
    }
