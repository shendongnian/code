    public class MyBaseMetroForm : MetroForm
        {
            //What is your style
            protected const MetroColorStyle FormStyle = MetroColorStyle.Pink;
            public MyBaseMetroForm() : base()
            {
            }
            public void SetStyle(IContainer container, Form1 ownerForm)
            {
                if (container == null)
                {
                    container = new System.ComponentModel.Container();
                }
                var manager = new MetroFramework.Components.MetroStyleManager(container);
                manager.Owner = ownerForm;
                container.SetDefaultStyle(ownerForm, FormStyle);
            }
        }
