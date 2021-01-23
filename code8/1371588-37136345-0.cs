               try
                {
                SqlCommand read = new SqlCommand();
                read.CommandType = CommandType.Text;
                read.Connection = connect;
                read.CommandText = "SELECT * FROM [viewstudent]";
                SqlDataReader get;
                get = read.ExecuteReader();
                while (get.Read())
                {
                    dt.Rows.Add(["studentid"].ToString(); get["firstname"].ToString(); get["lastname"].ToString(); get["gender"].ToString(); get["birthdate"].ToString(); get["streetadress"].ToString(); get["zipcode"].ToString(); get["country"].ToString();
                    get["city"].ToString(); get["studenttype"].ToString(); get["programname"].ToString(); get["year"].ToString(); get["credits"].ToString();
                }
                MessageBox.Show("Good!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error try again!");
            }
            connect.Close();
            return dt;
        }      
