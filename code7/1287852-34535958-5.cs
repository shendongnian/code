    public class Wrapper
        {
            public static List<empCategoryBLL_Result> EmployeeCategory()
            {
                try
                {
                    return new LOOKUPEntities().empCategoryBLL().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            public static void UpdateEmpCategory(int id, string description)
            {
                try
                {
                    using (LOOKUPEntities client = new LOOKUPEntities())
                    {
                        client.UpdateEmpCategoryBLL(id, description);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    
     6. copy the connection string from you app.config to your web.config. Then add your class library to your references by right clicking on your references and select add reference, select solution and click on add. Add also System.Data,Entity and click ok.
     7. now;
    
    
