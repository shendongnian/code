    string theXml = "";
    if(txtDesc.Text != null)
    {
        theXml = System.Net.WebUtility.HtmlEncode(txtDesc.Text.Trim());
        objParameter.Add(new SqlParameter("@Description", theXml));
    }
