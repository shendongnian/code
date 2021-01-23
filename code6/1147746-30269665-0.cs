    private void SearchItemOnList() {
       foreach (CellPhone c in newList) {                
            if (c.IEMI == txtSearchIEMI.Text) {
                txtDesciption.Text = c.Description;
                txtInPrice.Text = Convert.ToString(c.Price);
                txtInDate.Text = ""; //can't access inDate?
            }
        }
    }
