    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (IsValidQuotation())
        {
            string newQuotNum = rental_quotations.GetNewQuotNumber();
            double max_load = (Convert.ToDouble(generator_category.GetGeneratorDesc(ddl_gene_desc.SelectedValue)) * 0.8) * ((double)80 / (double)100);
            double min_load = (Convert.ToDouble(generator_category.GetGeneratorDesc(ddl_gene_desc.SelectedValue)) * 0.8) * ((double)50 / (double)100);
            rental_quotations.AddNewQuotation(newQuotNum, Session["empcd"].ToString(), ddl_gene_type.SelectedValue.ToString(), ddl_gene_desc.SelectedValue, ddl_canopy.SelectedValue, txt_company.Text, txt_address.Text, txt_contactperson.Text, txt_designation.Text, txt_contact1.Text, txt_contact2.Text, txt_rentalamount.Text, ddl_terms.SelectedValue, txt_hours.Text, txt_variable.Text, txt_remarks.Text, min_load.ToString(), max_load.ToString(),ddl_sign1.SelectedValue,ddl_sign2.SelectedValue);
            GetPDF(newQuotNum);
            ClearForm();
        }
    }
    private void ClearForm()
    {
        foreach( var control in this.Controls )
        {
             var textbox = control as TextBox;
             if (textbox != null)
                  textbox.Text = string.Empty;
             var dropDownList = control as DropDownList;
             if (dropDownList != null)
                  dropDownList.SelectedIndex = 0;
             
             }
     }
