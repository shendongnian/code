    [WebMethod]
    // note clear difference between single and multiple selections
    public static void deleteRecord(List<int> Id)
    {
        clsCategoryBL objproject = new clsCategoryBL();
    
        // iterate through input list and pass to process method
        for (int i = 0; i < Id.Count; i++) 
        {
            objproject.CategoryDelete(Id[i]);
        }
    }
    public String CategoryDelete(int CategoryID)
    {
        using (KSoftEntities db = new KSoftEntities())
        {
            try
            {
                var categoryDetails = db.tblCategories.Where(i => i.CategoryID == CategoryID).SingleOrDefault();
                db.tblCategories.Remove(categoryDetails);
                db.SaveChanges();
                // Advice: Place this line below somewhere after all iteration process finished
                return "Record deleted successfully"; 
            }
            catch (Exception ex)
            {
            }
            return "Error on deletion";
        }
    }
