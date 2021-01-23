                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = dataGridView1.Rows[index];
    
                Label lblName = (gvRow.FindControl("lbl_name") as Label);
                
                AmzEntities context = new AmzEntities();
                Sellers _sellers = new Sellers();
                _sellers.name= lblName.Text;
                context.Sellers.Add(_sellers);
                context.SaveChanges();
