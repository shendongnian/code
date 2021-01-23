    using (var con = new SqlConnection(string Con = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;))
         {
          string result;
          var cmd = new SqlCommand("Insert into PRODUCT(PRODUCT_NAME) Values (@mastertxt)",con);   
          cmd.Parameters.AddWithValue("@mastertxt",Master_product_txt.Text);
          con.Open();
          int flag = cmd.ExecuteNonQuery();
          con.Close();
          if (flag == 1)
            {
             result = "Add record";
            }
          else
            {
             result = "Fail Insertion";
            }
           return result;
    
         }  
