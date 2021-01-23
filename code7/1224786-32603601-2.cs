    private void AddItemsForAmy(){
        myConn = new SqlConnection("Server = localhost; Initial Catalog=dbName         Trusted_Connection=true;"
        string query = "Select * from item_Detail where itemId % 2 = 0"
        myCommand = new SqlCommand(query, myConn);
        try{
          myConn.Open();
          myReader = myCommand.ExecuteReader();
          
          while(myReader.Read()){
          string itemName = myReader["itemName"].toString();
          myCheckListBox.Items.Add(itemName);
          }
          myConn.Close();
        }
        catch(SqlExcetion ex){
               MessageBox.Show(ex.Message);
        }
    }
