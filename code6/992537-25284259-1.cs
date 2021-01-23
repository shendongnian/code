    using (Sqldbconn dbconn = new Sqldbconn(connStr))
        {
            string sql = "SELECT l.Field, d.field FROM S.dbo.letters l 
                    INNER JOIN S.dbo.ds d ON l.sID= d.sID WHERE l.id=@primaryID";
    
            SqlCommand cmd = new SqlCommand(sql.ToString(), dbconn);
    		cmd.Parameters.AddWithValue("@primaryID", 1);//Session["primIDedit"]
    
            dbconn.Open();
    		
            LetterInfo letterInfo = new LetterInfo();
    		var counter = 0;
    
            using (var rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
    				 var recipient = new Recipient();
    				 recipient.FirstName = myReader["dfname"].ToString()
    				 recipient.LastName = myReader["..."].ToString()
    				 ....
    				 letterInfo.Recipients.Add(recipient);
                             
    				 //only need to populate the letterinfo once.
    				 if (counter == 0){
                         //use field name here, not the ordinal number
    					 letterInfo.Paragraph1 = myReader[9].ToString();
    					 letterInfo.Paragraph2 = myReader[10].ToString();
    					 letterInfo.Paragraph3 = myReader[11].ToString();
    					 ....
    				  }
    						 
    					 counter++;
                      }                   
                }
        }
