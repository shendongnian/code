         public void changebackground()
    {           
            Label mylabel;
            foreach (Control con in this.Controls) 
            
            {
                if (con.GetType() ==typeof (Label)) //or any other logic
                {
                    mylabel = (Label)con;
                    mylabel.BackColor = Color.Red;
                }
            }
        }
