    using System;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication1
    {
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LineBreaker lb = new LineBreaker(4);
            this.Controls.Add(lb);
        }
    }
    public static class HtmlConstants
    {
        public const string Br = @"<br />";
    }
    public class LineBreaker : WebControl
    {
        public LineBreaker(int lineCount)
        {
            LineCount = lineCount;
        }
        public int LineCount { get; set; }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(CreateLineBreaker(LineCount));
            base.Render(writer);
        }
        public string CreateLineBreaker(int howManyLines)
        {
            string result = String.Empty;
            StringBuilder sb = new StringBuilder();
            if (howManyLines > 0)
            {
                for (int i = 0; i < howManyLines; i++)
                {
                    sb.Append(HtmlConstants.Br);
                }
                result = sb.ToString();
            }
            return result;
        }
    }
    }
