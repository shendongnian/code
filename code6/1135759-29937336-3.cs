    public class BasePage : Page
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.ReplaceLabel(this); 
            base.Render(writer);
            
        }
        private void ReplaceLabel(Control control)
        {
            if (control is Label)
            {
                Label lbl = (Label)control;
                if (lbl.Text == "Community")
                {
                    ModeType mode = this.Context.Session["Mode"];
                    if (mode == ModeType.People)
                    {
                        lbl.Text = "People";
                    }
                }
            }
            else
            {
                foreach (Control childControl in control.Controls)
                {
                    this.ReplaceLabel(childControl);
                }
            }
        }
    }
