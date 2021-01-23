    var pnlMain = new System.Windows.Forms.Panel(); // replace with your container (where your textboxes exists)
    for (i = 1; intCOUNTRIES > i; i++)
    {
       LC = ((TextBox)pnlMain.Controls.Find("inputCOUNTRY" + i)[0]).Text;
       strCountryName = Country(LC);
       strCountries += strCountryName + ", ";  
    }
