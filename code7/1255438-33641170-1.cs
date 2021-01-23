    public class RadioButtonAdapter : System.Web.UI.Adapters.ControlAdapter {
        protected override void BeginRender(HtmlTextWriter writer) {
            writer.Write("<div class=\"wrapper\">");
            base.BeginRender(writer);
        }
        protected override void EndRender(HtmlTextWriter writer) {
            base.EndRender(writer);
            writer.Write("</div>");
        }
    }
