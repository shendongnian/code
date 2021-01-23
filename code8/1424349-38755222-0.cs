    int? tenISBN = null,
        vendISBN = null;
    int iParse;
    
    long? lng = null;
    long lParse;
    
    if (!string.IsNullOrWhiteSpace(txtISBN.Text) && long.TryParse(txtISBN.Text, out lParse))
        lng = lParse;
    
    if (!string.IsNullOrWhiteSpace(txtP1.Text) && int.TryParse(txtP1.Text, out iParse))
        tenISBN = iParse;
    
    if (!string.IsNullOrWhiteSpace(txtVendorISBN.Text) && int.TryParse(txtVendorISBN.Text, out iParse))
        vendISBN = iParse;
    
    
    if (lng.HasValue) //lng has value
    {
        //DO Your work
    }
