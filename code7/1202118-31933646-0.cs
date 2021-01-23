    using System.IO;
    using System.Text;
    using System.Data;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.html.simpleparser;
    
    protected void GenerateInvoicePDF(object sender, EventArgs e)
    {
        //Dummy data for Invoice (Bill).
        string companyName = "ASPSnippets";
        int orderNo = 2303;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] {
                                new DataColumn("ProductId", typeof(string)),
                                new DataColumn("Product", typeof(string)),
                                new DataColumn("Price", typeof(int)),
                                new DataColumn("Quantity", typeof(int)),
                                new DataColumn("Total", typeof(int))});
        dt.Rows.Add(101, "Sun Glasses", 200, 5, 1000);
        dt.Rows.Add(102, "Jeans", 400, 2, 800);
        dt.Rows.Add(103, "Trousers", 300, 3, 900);
        dt.Rows.Add(104, "Shirts", 550, 2, 1100);
     
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                StringBuilder sb = new StringBuilder();
     
                //Generate Invoice (Bill) Header.
                sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                sb.Append("<tr><td colspan = '2'></td></tr>");
                sb.Append("<tr><td><b>Order No: </b>");
                sb.Append(orderNo);
                sb.Append("</td><td align = 'right'><b>Date: </b>");
                sb.Append(DateTime.Now);
                sb.Append(" </td></tr>");
                sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                sb.Append(companyName);
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("<br />");
     
                //Generate Invoice (Bill) Items Grid.
                sb.Append("<table border = '1'>");
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
                    sb.Append(column.ColumnName);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(row[column]);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("<tr><td align = 'right' colspan = '");
                sb.Append(dt.Columns.Count - 1);
                sb.Append("'>Total</td>");
                sb.Append("<td>");
                sb.Append(dt.Compute("sum(Total)", ""));
                sb.Append("</td>");
                sb.Append("</tr></table>");
     
                //Export HTML String as PDF.
                StringReader sr = new StringReader(sb.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderNo + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
