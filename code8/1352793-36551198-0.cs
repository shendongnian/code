            SqlDataReader drb;
            drb = command.ExecuteReader();
            while (drb.Read())
            {
                sNum = drb["ID"].ToString();
                sWord = drb["Element"].ToString();
                MessageBox.Show("OUTER loooop sNum = " + sNum + " sWord = " + sWord);
        
        
                sql2 = "SELECT * from mybrknElements2; ";
                String sWord2 = "" ;
                String sNum2 = "";
                SqlCommand command22 = new SqlCommand(sql2, cnn2);
        
                SqlDataReader drcc;
                drcc = command22.ExecuteReader(); //ERROR comes up after this line 
        
              drb.Close();
                while (drcc.Read())
                {
                    sNum2 = drcc["ID"].ToString();
                    sWord2 = drcc["Element"].ToString();
                    if (Equals(sWord2,sWord2))
                    {
        
                        nWords = nWords + 1;
                        MessageBox.Show("sNum2 = " + sNum2 + " sWord2 = " +   sWord2);
                     }
                   }
                drcc.Close();
              }
