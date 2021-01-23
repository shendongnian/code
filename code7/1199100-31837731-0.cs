    foreach (DataListItem li in DataList1.Items)
    {
    
        //access the check checklist
        HtmlInputCheckBox cb = li.FindControl("FavChkBox") as HtmlInputCheckBox;
        if (cb != null && cb.Checked)
        {
            ArrayList Product = new ArrayList();
    
            LblText.Text += " , ";
    
            LblText.Text += cb.Value;
            Product.Add(cb.Value);
        }
    Session.Add("SelectedProducts", Product);
            string url = "CompareProducts.aspx?hasProducts=true;
            Response.Redirect(url);
    }
