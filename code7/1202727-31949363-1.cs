    foreach (Control c in pnlThumbs.Controls) 
    {
        if ((c.Tag != null)) 
        {
            string GUID = Convert.ToString((object[])c.Tag(0));
        }
    }
