    public class TemplateModule01 : Your.NS.TemplateModule
    {
        protected override void ContextBeginRequest(object sender, EventArgs e)
        {
            _arg1 = "~/something";
            _arg2 = "500";
            base.ContextBeginRequest(sender, e);
        }
    }
    public class TemplateModule02 : Your.NS.TemplateModule
    {
        protected override void ContextBeginRequest(object sender, EventArgs e)
        {
            _arg1 = "~/otherthing";
            _arg2 = "100";
            base.ContextBeginRequest(sender, e);
        }
    }
