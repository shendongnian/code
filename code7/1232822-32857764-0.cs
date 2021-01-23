    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Component component = FindControl(this.Controls, "toolStripStatusLabel1");
            label2.Text = component != null ?
                "Found control named \"" + GetNameForComponent(component) + "\"" :
                "No control was found";
        }
        private static string GetNameForComponent(Component component)
        {
            Control control = component as Control;
            if (control != null)
            {
                return control.Name;
            }
            ToolStripItem item = component as ToolStripStatusLabel;
            if (item != null)
            {
                return item.Name;
            }
            return "<unknown Component type>";
        }
        private Component FindControl(IEnumerable controlCollection, string name)
        {
            foreach (Component component in controlCollection)
            {
                if (GetNameForComponent(component) == name)
                {
                    return component;
                }
                IEnumerable childControlCollection = GetChildrenForComponent(component);
                if (childControlCollection != null)
                {
                    Component result = FindControl(childControlCollection, name);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
        private static IEnumerable GetChildrenForComponent(Component component)
        {
            ToolStrip toolStrip = component as ToolStrip;
            if (toolStrip != null)
            {
                return toolStrip.Items;
            }
            Control control = component as Control;
            if (control != null)
            {
                return control.HasChildren ? control.Controls : null;
            }
            return null;
        }
    }
