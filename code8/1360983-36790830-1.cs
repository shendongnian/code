    void btnAdd_Click(object sender, EventArgs e)
    {
       i=1       
            while ( i<5 )      
                {
                  if (tRow[i].Visible & !tRow[i+1].Visible)        
                      {
                          tRow[i+1].Visible = true;
                          Break;
                      }
                  else
                     i++;
                }
    }
