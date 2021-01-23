    public class gymArray
    {
      public List<string> names { get; set; }
    }
    
    public gymArray getAllGymsByStars()
    {
      gymDataTableAdapters.gymsTableAdapter gymsTableAdapter = new gymDataTableAdapters.gymsTableAdapter();
      DataTable gymsDataTable = gymsTableAdapter.getAllGymsByStars();
      gymArray gymArray = new gymArray();
      gymArray.names = new List<string>();
    
      foreach(DataRow row in gymsDataTable.Rows)
      {
         gymArray.names.Add(row["name"].ToString());        
      }
      return gymArray;
    }
