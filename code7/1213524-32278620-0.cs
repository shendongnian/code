    public class GymInfo
    {
       public List<Gym> GetAllGymsByStars()
       {
            gymDataTableAdapters.gymsTableAdapter gymsTableAdapter = new gymDataTableAdapters.gymsTableAdapter();
            DataTable gymsDataTable = gymsTableAdapter.getAllGymsByStars();    
            List<Gym> gyms = new List<Gym>();    
            foreach(DataRow row in gymsDataTable.Rows)
            {
                Gym gym = new Gym();
                gym.Name = row["name"].ToString();
                gyms.Add(gym);      
            }
            return gyms;
        }
    }
    public class Gym
    {
         public string Name { get; set; }
    }
