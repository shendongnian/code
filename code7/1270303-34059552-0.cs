     TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://servername:8080/tfs/DefaultCollection"));
            ITestManagementTeamProject project = tfs.GetService<ITestManagementService>().GetTeamProject("teamproject");
            ITestCase testcase24 = project.TestCases.Find(24); //24 is the test case id
      
            foreach (System.Data.DataTable dataTable in testcase24.Data.Tables)
            {
                string header = "";
                foreach (System.Data.DataColumn colume in dataTable.Columns)
                {
                    header += colume.ColumnName + "\t";
                }
                Console.WriteLine(header);
                foreach (System.Data.DataRow row in dataTable.Rows)
                {
                    string rowValue = "";
                    foreach (object o in row.ItemArray)
                    {
                        rowValue += o.ToString() + "\t";
                    }
                    Console.WriteLine(rowValue);
                }
            }
