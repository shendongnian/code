            using (var db = new DbEntities())
                {
                    foreach (user in db)
                    {
  			            var userExists = db.DB_USER.Where(u => u.ID == user.ID);
		    	        if(!userExists)
    			        {
                        	var newUser = new DB_USER
                        	{
                            		ID = Int32.Parse(worksheet.Cells[idColumn + row].Value.ToString()),
                            		FIRST_NAME = worksheet.Cells[firstNameColumn + row].Value.ToString(),
                            		LAST_NAME = worksheet.Cells[lastNameColumn + row].Value.ToString(),                               
                        	};
                       		try
                  		    {
                                db.DB_USER.Add(newUser);
                          		db.SaveChanges();
                                totalImported++;
                        	}
                        	catch (Exception ex)
                        	{
                                 resultMessages.Add(string.Format("Error in line #{0}: {1}\n", row,
                                 ex.Message));
                        	}
		    	        }
                    }
                }
