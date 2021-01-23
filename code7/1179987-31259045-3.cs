    public partial class TabControl : System.Web.UI.UserControl
        {
            public event EventHandler<ControlChangedEventArgs> ControlUpdated;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                TextBox textBox = new TextBox();
                textBox.AutoPostBack = true;
                textBox.ID = "textBox";
    
                textBox.TextChanged += textBox_TextChanged;
    
                DropDownList dropDown = new DropDownList();
                dropDown.Items.Add(new ListItem("Option 1", "Option 1"));
                dropDown.Items.Add(new ListItem("Option 2", "Option 2"));
                dropDown.AutoPostBack = true;
    
                dropDown.TextChanged += dropDown_TextChanged;
    
                panel.Controls.Add(textBox);
                panel.Controls.Add(dropDown);
            }
    
            void dropDown_TextChanged(object sender, EventArgs e)
            {
                ControlChangedEventArgs args = new ControlChangedEventArgs();
    
                args.ControlID = ((DropDownList)sender).ID;
                args.ControlValue = ((DropDownList)sender).SelectedValue;
    
                ControlUpdated(this, args);
    
                //CODE EDIT:
                UnhookEventHandlers();
    
            }
    
            void textBox_TextChanged(object sender, EventArgs e)
            {
                ControlChangedEventArgs args = new ControlChangedEventArgs();
                args.ControlID = ((TextBox)sender).ID;
                args.ControlValue = ((TextBox)sender).Text;
                ControlUpdated(this, args);
    
                //CODE EDIT:
                UnhookEventHandlers();
    
            }
    
            public virtual void OnControlUpdated(ControlChangedEventArgs e)
            {
                EventHandler<ControlChangedEventArgs> handler = ControlUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
    
                //CODE EDIT:
                UnhookEventHandlers();
    
            }
    
            //CODE EDIT:
            private void UnhookEventHandlers()
            {
                foreach (var c in panel.Controls.OfType<DropDownList>())
                {
                    c.TextChanged -= dropDown_TextChanged;
                }
    
                foreach (var c in panel.Controls.OfType<TextBox>())
                {
                    c.TextChanged -= textBox_TextChanged;
                }
            }
    
        }
    
        public class ControlChangedEventArgs : EventArgs
        {
            public string ControlID { get; set; }
            public string ControlValue { get; set; }  
        }
