    public class MyCustomAudio : System.Web.UI.HtmlControls.HtmlAudio
    {
        protected override void RenderAttributes(HtmlTextWriter writer)
        {
            foreach (string key in this.Attributes.Keys)
            {
                String val = this.Attributes[key];
                writer.Write(val == key
                    ? String.Format(" {0}", key)
                    : String.Format(" {0}=\"{1}\"", key, val));
            }
        }
    }
