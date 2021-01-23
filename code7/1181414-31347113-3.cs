    using NReco.PdfGenerator;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    namespace DMC.Classes
    {
        public class export 
        {
            public void exportPDF(string fileName, string Orientation, string html)
            {
                HtmlToPdfConverter pdf = new HtmlToPdfConverter();
	            //Remove these control characters, they interfere with the formatting of the pdf document
                html = html.Replace("\n", "");
                html = html.Replace("\t", "");
                html = html.Replace("\r", "");
                switch (Orientation)
                {
                    case "Portrait":
                        pdf.Orientation = PageOrientation.Portrait;
                        break;
                    case "Landscape":
                        pdf.Orientation = PageOrientation.Landscape;
                        break;
                    default:
                        pdf.Orientation = PageOrientation.Default;
                        break;
                }
                //In case needed for future
                //pdf.CustomWkHtmlArgs = "--margin-top 35 --header-spacing 0 --margin-left 0 --margin-right 0";
                pdf.Margins.Top = 25;
                pdf.PageFooterHtml = createPDFFooter();
                var pdfBytes = pdf.GeneratePdf(createPDFScript() + html + "</body></html>");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".pdf");
                HttpContext.Current.Response.BinaryWrite(pdfBytes);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            private string createPDFScript()
            {
                return "<html><head><style>td,th{line-height:20px;} tr { page-break-inside: avoid }</style><script>function subst() {var vars={};var x=document.location.search.substring(1).split('&');for(var i in x) {var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}" +
            "var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];for(var i in x) {var y = document.getElementsByClassName(x[i]);" +
            "for(var j=0; j<y.length; ++j) y[j].textContent = vars[x[i]];}}</script></head><body onload=\"subst()\">";
            }
            private string createPDFFooter()
            {
                return "<div><table style='font-family:Tahoma; font-size:9px; width:100%'><tr><td style='text-align:left'>Research Dept|RR:mm:jpg</td><td style='text-align:right'>Page <span class=\"page\"></span> of <span class=\"topage\"></span></td></div>";
            }
        }
    }
