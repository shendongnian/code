    protected void PendingOrdersPDF_Click(object sender, EventArgs e)
            {
                if (PendingOrdersGV.Rows.Count > 0)
                {
                    //to allow paging=false & change style.
                    PendingOrdersGV.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    PendingOrdersGV.BorderColor = Color.Gray;
                    PendingOrdersGV.Font.Name = "Tahoma";
                    PendingOrdersGV.DataSource = clsBP.get_PendingOrders(lbl_BP_Id.Text);
                    PendingOrdersGV.AllowPaging = false;
                    PendingOrdersGV.Columns[0].Visible = false; //export won't work if there's a link in the gridview
                    PendingOrdersGV.DataBind();
    
                    //to PDF code --Sam
                    string attachment = "attachment; filename=report.pdf";
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/pdf";
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);
                    htextw.AddStyleAttribute("font-size", "8pt");
                    htextw.AddStyleAttribute("color", "Grey");
                    
                    PendingOrdersPanel.RenderControl(htextw);//Name of the Panel
                    Document document = new Document();
                    document = new Document(PageSize.A4, 5, 5, 15, 5);
                    FontFactory.GetFont("Tahoma", 50, iTextSharp.text.BaseColor.BLUE);
                    PdfWriter.GetInstance(document, Response.OutputStream);
                    document.Open();
    
                    StringReader str = new StringReader(stw.ToString());
                    HTMLWorker htmlworker = new HTMLWorker(document);
                    htmlworker.Parse(str);
    
                    document.Close();
                    Response.Write(document);
                }
