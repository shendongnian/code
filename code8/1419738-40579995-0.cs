        public void ClearAllFields(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox && c != null)
                {
                    if (c.Name != "specialtxtbox1name" && c.Name != "specialtxtbox2name" && c.Name != "nameoftextbox") // just put in the name of special textBoxes between double quotes
                        c.Text = "";
                }
                else
                {
                    ClearAllFields(c);
                }
            }
            
        }
