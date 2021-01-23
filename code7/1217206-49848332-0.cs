        public static string GetCFConnection()
        {
            string Connection = "";
            string Machine = System.Environment.MachineName.ToLower();
            switch(Machine)
            {
                case "development":
                    Connection = @"Data Source=DEV_SRV;Initial Catalog=CeaseFire;Integrated Security=True"; 
                    break;
                case "production":
                    Connection = @"Data Source=PRO_SRV;Initial Catalog=CeaseFire;Integrated Security=True";
                    break;
            }
            return Connection;
        }
