    public double totalPhone()
    {
        double total = 0;
        Dictionary<string,double> items = new Dictionary<string,double>();
        items.Add(chkPhone1.ID,2249); // ID,Text whatever works
        items.Add(chkPhone2.ID,1769);
        items.Add(chkPhone3.ID,3099);
        items.Add(chkPhone4.ID,1198);
        items.Add(chkPhone5.ID,1899);
       
        foreach(Control c in this.Controls)
        { 
            if(c is CheckBox && c.Checked)
            {
                 total += (items[c.ID] != null ? items[c.ID] : 0);
            }
        }
        return total;
    }
