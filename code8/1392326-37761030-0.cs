            //Test Data 
            DataTable Companies = new DataTable();
            Companies.Columns.Add("Companyid", typeof(string));
            Companies.Columns.Add("CompanyName", typeof(string));
            DataTable Teams = new DataTable();
            Teams.Columns.Add("Companyid", typeof(string));
            Teams.Columns.Add("TeamID", typeof(string));
            DataTable ApplicationUserTeam = new DataTable();
            ApplicationUserTeam.Columns.Add("TeamID", typeof(string));
            ApplicationUserTeam.Columns.Add("ApplicationUserID", typeof(string));
            DataTable AspnetUsers = new DataTable();
            AspnetUsers.Columns.Add("ID", typeof(string));
            AspnetUsers.Columns.Add("Name", typeof(string));
            Companies.Rows.Add("10", "Infosys");
            Companies.Rows.Add("12", "Tech mahindra");
            Teams.Rows.Add("10", "T18");
            Teams.Rows.Add("12", "T12");
            ApplicationUserTeam.Rows.Add("T10", "120");
            ApplicationUserTeam.Rows.Add("T12", "110");
            AspnetUsers.Rows.Add("110", "king");
            AspnetUsers.Rows.Add("112", "little");
            var id = AspnetUsers.AsEnumerable().Where(s => s.Field<string>("Name").Equals("king")).Select(s => s.Field<string>("ID")).First();
            var Teamid = ApplicationUserTeam.AsEnumerable().Where(s => s.Field<string>("ApplicationUserID").Equals(id)).Select(s => s.Field<string>("TeamID")).First();
            var Companyid = Teams.AsEnumerable().Where(s => s.Field<string>("TeamID").Equals(Teamid)).Select(s => s.Field<string>("Companyid")).First();
            var Company = Companies.AsEnumerable().Where(s => s.Field<string>("Companyid").Equals(Companyid));
            foreach (var item in Company)
            {
                Console.WriteLine(item[0] + "  " + item[1]);
            }
