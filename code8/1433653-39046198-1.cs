        public ActionResult Create(List<Contact> model)
        {
            string query = "INSERT INTO Contact (Id, FirstName, LastName, Email, "
                         + "Phone, CompanyId) values (@Id,@FirstName,@LastName"
                         + ",@Email,@Phone,@CompanyID)";
            using (var connection = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Sublime;Integrated Security=True"))
            {
                connection.Open();
                foreach(Contact modelElement in model)
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Id", modelElement.Id);
                    command.Parameters.AddWithValue("@FirstName", modelElement.FirstName);
                    command.Parameters.AddWithValue("@LastName", modelElement.LastName);
                    command.Parameters.AddWithValue("@Email", modelElement.Email);
                    command.Parameters.AddWithValue("@Phone", modelElement.Phone);
                    command.Parameters.AddWithValue("@CompanyID", modelElement.CompanyID);
                    command.ExecuteNonQuery();
                }
            }
        }
