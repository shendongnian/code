    var filter = string.Empty;
    
    if (String.IsNullOrEmpty(tbName.Text))
    {
        filter += "Name LIKE '%" + tbName.Text + "%'";
    }
    if (String.IsNullOrEmpty(tbSifraTransakcije.Text))
    {
        if (!String.IsNullOrEmpty(filter))
        {
            filter += " AND ";
        }
        filter += "MiddleName LIKE '%" + tbMiddleName.Text + "%'";
    }
    if (String.IsNullOrEmpty(tbSurname.Text))
    {
         if (!String.IsNullOrEmpty(filter))
        {
            filter += " AND ";
        }
        filter += "Surname LIKE '%" + tbSurname.Text + "%'";
    }
    bsAllPeople.Filter = filter;
