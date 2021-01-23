    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyControlDesigner))]
    public class MyControl : Control
    {
        public string SomeProperty { get; set; }
    }
    public class MyControlDesigner : ControlDesigner
    {
        private void SomeMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Some Method!");
            var p = TypeDescriptor.GetProperties(this.Control)["SomeProperty"];
            p.SetValue(this.Control, "some value returned from form");
        }
        DesignerVerbCollection verbs;
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                {
                    verbs = new DesignerVerbCollection();
                    verbs.Add(new DesignerVerb("Do Something!", SomeMethod));
                }
                return verbs;
            }
        }
    }
