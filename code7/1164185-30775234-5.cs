    if (Tip == "Firma")
    {
        foreach (Control item in yourDiv.Controls)
         {
            item.Visible = false;
         }
        fsFirma.Visible = true;
        lblFirmaInfo.Visible = true;
    }
