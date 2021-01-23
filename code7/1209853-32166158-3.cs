        public enum Status
        {
            Success = 0,
            None,
            RetryUser,
            RetryInfra,
            Network,
            Boom,
            MAX
        }
        public Status ConnectionStatus()
        {
            Status status = Status.None;
            try
            {
                Database db = new SqlDatabase(connectionString);
                using (var connection = db.CreateConnection())
                {
                    connection.Open();
                    status = Status.Success;
                }
            }
            catch (IOException)
            {
                status = Status.Network;
            }
            catch (SqlException ex)
            {
                switch (ex.Class)
                {
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        status = Status.RetryUser;
                        break;
                    case 20:
                        status = Status.RetryInfra;
                        break;
                    default:
                        status = Status.Boom;
                        break;
                }
            }
            return status;
        }
