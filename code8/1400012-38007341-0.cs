    public void CreatePDF(string quote_num)
    {
        string url = FilesPath.Path_SaveFile + Session["empcd"].ToString() +"-Quotation.pdf";
        Document disclaimer = new Document(PageSize.A4, 2, 2, 10, 10);
        PdfWriter writer = PdfWriter.GetInstance(disclaimer, new FileStream(url, FileMode.Create));
        writer.PageEvent = new myPDFpgHandler(quote_num);
        disclaimer.SetMargins(70, 10, 60, 80);    
        disclaimer.Open();
        GenerateQuotPDF getpdf = new GenerateQuotPDF();
        disclaimer = getpdf.GetPDFparams(disclaimer,quote_num, Session["empcd"].ToString(),txt_contactperson.Text,txt_contact1.Text,txt_company.Text,txt_address.Text,ddl_gene_desc.SelectedItem.ToString(),ddl_canopy.SelectedItem.ToString(),ddl_gene_type.SelectedItem.ToString(),txt_rentalamount.Text,txt_hours.Text,txt_variable.Text,ddl_terms.SelectedItem.ToString(),txt_remarks.Text,txt_technical.Text,ddl_sign1.SelectedValue,ddl_sign2.SelectedValue,txt_designation.Text,DateTime.Now);
        disclaimer.Close();
    }
