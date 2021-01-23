    private void SearchItemOnList()
    {
       foreach (InDate c in newList)
        {                
            if (c.IEMI == txtSearchIEMI.Text)
            {
                txtDesciption.Text = c.Description;
                txtInPrice.Text = Convert.ToString(c.Price);
                txtInDate.Text = ""; //can't access inDate?
            }
        }
    }
