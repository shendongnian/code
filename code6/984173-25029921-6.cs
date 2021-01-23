    public class DropDownTemplateField : ITemplate
    {
        int[] options = new int[] { 1, 2, 3, 4 };
        public void InstantiateIn(Control container)
        {
            DropDownList ddl = new DropDownList();
            ddl.DataSource = options;
            foreach (int value in options)
            {
                ddl.Items.Add(new ListItem(value.ToString(), value.ToString()));
            }
            container.Controls.Add(ddl);
        }
    }
    public class ButtonTemplateField : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            Button btn = new Button();
            btn.CommandName = "foo";
            btn.Text = "Click me";
            container.Controls.Add(btn);
        }
    }
    public class TextTemplateField : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            TextBox tbx = new TextBox();
            tbx.ID = "tbx1";
            container.Controls.Add(tbx);
        }
    }
