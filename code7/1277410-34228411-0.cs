    using (var session = new Configuration().Configure().BuildSessionFactory().OpenSession())  
            {  
                ClassCodes classcodes=session.Get<ClassCodes>(Originalcode);
    
                classcodes.EquivalanceCode="EquivalanceCode value";
        
                using (ITransaction transaction = session.BeginTransaction())  
                {  
                    session.SaveOrUpdate(classcodes);  
                    transaction.Commit();  
                }  
            }
