    public class gymInfo
    {
       public gymArray[] getAllGymsByStars()
       {
    	   int count = 0;
            gymDataTableAdapters.gymsTableAdapter gymsTableAdapter = new gymDataTableAdapters.gymsTableAdapter();
            DataTable gymsDataTable = gymsTableAdapter.getAllGymsByStars();
            gymArray[] gymArray = new gymArray[gymsDataTable.Rows.Count];
    
            foreach(DataRow row in gymsDataTable.Rows)
            {
    			gymArray[count] = new gymArray();
                gymArray[count].name = row["name"].ToString();
    			count++;
            }
            return gymArray;
        }
    }
