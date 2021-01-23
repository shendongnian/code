            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                    
                HyperLink hlContro = new HyperLink();
                hlContro.NavigateUrl = "./newPage.aspx?ID=" + GridView1.Rows[i].Cells[3].Text; //This is where your url is being kept in the grid
             hlContro.Text = "Click me to go to the link";
               GridView1.Rows[i].Cells[3].Controls.Add(hlContro);//adds the control to the gridview
                               
            }
            
