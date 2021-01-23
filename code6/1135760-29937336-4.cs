    public class CustomModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }
        private void context_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Handler is Page)
            {
                Page page = (Page)HttpContext.Current.Handler;
                page.PreRenderComplete += page_PreRenderComplete;
            }
        }
        private void page_PreRenderComplete(Object sender, EventArgs e)
        {
            Page page = (Page)sender;
            this.ReplaceLabel(page);
        }
        public void Dispose()
        { }
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
