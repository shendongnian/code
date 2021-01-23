    private void My_OnRowUpdate(object sender, OleDbRowUpdatedEventArgs e)
    {             
       if(e.StatementType==StatementType.Insert) 
       {                
          // reads the identity value from the output parameter @ID
          object ai = e.Command.Parameters["@ID"].Value;
    
          // updates the identity column (autoincrement)                   
          foreach(DataColumn C in e.Row.Table.Columns)
          {
             if(C.AutoIncrement)
             {
                C.ReadOnly = false;                      
                e.Row[C] = ai;  
                C.ReadOnly = true;
                break; // there can be only one identity column
             }      
          }                        
    
          e.Row.AcceptChanges();             
       }
    }
