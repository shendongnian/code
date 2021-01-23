    using (var myTransaction = Context.Database.BeginTransaction())
                    {
                        try
                        {
        				   //Crate Parent Object
        				   Context.SaveChanges();
        				   //Create Child Object;
        					   Context.SaveChanges();
        					   //Other Childs
        					     Context.SaveChanges();
        						 //If everything goes well
        						 myTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            myTransaction.Rollback();
                        }
                    }
