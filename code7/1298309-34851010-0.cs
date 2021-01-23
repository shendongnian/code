        status = textBox1.Text;
        allocated = textBox2.Text;
        
        BindingSource bs = new BindingSource();
        bs.DataSource = customerDataGridView.DataSource;
        
       var filt = "";
    
    
        if (!string.IsNullOrEmpty(status))
           {
             if(filt == "")
                filt  += "[Status] LIKE '%" + status + "%'";
             else
                filt += " And [Status] LIKE '%" + status + "%' ";
           }
    
    
          if (!string.IsNullOrEmpty(allocated))
               {
                 if(filt == "")
                    filt  += "[AssignedTo] LIKE '%" + allocated + "%'";
                 else
                    filt += " And [AssignedTo] LIKE '%" + allocated + "%' ";
               }
        
             if (!string.IsNullOrEmpty(param3))
              {
                 if(filt == "")
                    filt  += "[param3] LIKE '%" + param3+ "%'";
                 else
                    filt += " And [param3] LIKE '%" + param3+ "%' ";
              }
    
         bs.Filter = filt ;
        customerDataGridView.DataSource = bs;
