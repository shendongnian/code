    [WebMethod(EnableSession = true)]
        public static object DeleteDepartment(int id)
        {
            try
            {
    
                using (HRISDBEntities db = new HRISDBEntities())
                {
                    var deletedmember = db.tbl_Department.First(e => e.id == id);
                    db.tbl_Department.Remove(deletedmember);
                    db.SaveChanges();
                    return new { Result = "OK" };
    
                }
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
    
        }
