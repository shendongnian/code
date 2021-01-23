            //using (SqlConnection connection = new SqlConnection(connectionString))
            using (DbCommunicationDataContext context = new DbCommunicationDataContext(connectionString))
            {
                var result = context.gprefs.FirstOrDefault();
                if (result != null)
                {
                    wcf = result.cportlserver;
                    resend = result.ndatsentaft.ToString();
                }
            }
