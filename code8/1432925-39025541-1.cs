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
            MessageBox.Show("Some Message!"); 
        }
        private void SomeOtherMethod(object sender, EventArgs e)
        {
            var p = TypeDescriptor.GetProperties(this.Control)["SomeProperty"];
            p.SetValue(this.Control, "some value"); /*You can show a form and get value*/
        }
        DesignerVerbCollection verbs;
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                {
                    verbs = new DesignerVerbCollection();
                    verbs.Add(new DesignerVerb("Do something!", SomeMethod));
                    verbs.Add(new DesignerVerb("Do something else!", SomeOtherMethod));
                }
                return verbs;
            }
        }
    }
