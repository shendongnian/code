    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private HyperLink lnk;
            private Button btn;
    
            protected override void CreateChildControls()
            {
                base.CreateChildControls();
    
                lnk = new HyperLink();
                lnk.ID = "lnk";
                lnk.Text = "<b>Sample Link</b>";
                lnk.NavigateUrl = "http://www.google.com";
    
                btn = new Button();
                btn.ID = "btn";
                btn.Text = "button text";
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected override void Render(HtmlTextWriter writer)
            {
                StringBuilder sb = new StringBuilder();
                HtmlTextWriter myWriter = new HtmlTextWriter(new System.IO.StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture));
    
                base.Render(myWriter);
    
                myWriter.Flush();
    
                string renderedHtml = sb.ToString();
                renderedHtml = renderedHtml.Replace("##token##", RenderHTML(lnk));
                renderedHtml = renderedHtml.Replace("##button##", RenderHTML(btn));
    
                writer.Write(renderedHtml);
                myWriter.Close();
                sb.Clear();
            }
    
            private string RenderHTML(Control ctrl)
            {
                StringBuilder sb = new StringBuilder();  
                HtmlTextWriter myWriter = new HtmlTextWriter(new System.IO.StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture));
    
                ctrl.RenderControl(myWriter);
    
                myWriter.Close();
                return sb.ToString();
            }
        }
    }
