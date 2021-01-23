         public class DataService
         {
        private readonly SQLiteConnection _connection;
        public DataService()
        {
            _connection = new SQLiteConnection("DataBase.db");
        }
        public async Task<List<Data>> GetAllCities()
        {
            var cities = new List<Data>();
            using (var statement = _connection.Prepare("SELECT * FROM Data"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    cities.Add(new Data()
                    {
                        Id = (long)statement[0],
                        City = (string)statement[1],
                        Area = (string)statement[2]                      
                    });
                }
            }
            return cities;
        }
    }
