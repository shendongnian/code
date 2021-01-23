    protected void Page_Load(object sender, EventArgs e)
            {
                List<string> environment = new List<String>();
                List<string> application = new List<String>();
                List<string> serverrole = new List<String>();
                List<string> servers = new List<String>();
                
                ReadCSV(environment, application, serverrole, servers);
                
                string[] envlist = environment.ToArray();
                string[] applist = application.ToArray();
                string[] srvrolelist = serverrole.ToArray();
                string[] serverlist = servers.ToArray();
                dropdown_app.DataSource = applist.Skip(1).Distinct();
                dropdown_app.DataBind();
                srvrole.DataSource = srvrolelist.Skip(1).Distinct();
                srvrole.DataBind();
            }
            public static void ReadCSV(List<string> environment, List<string> application, List<string> serverrole, List<string> servers) 
            {
                StreamReader reader = new StreamReader(File.OpenRead(@"\\server\shares\App\Reference\Farms.csv"));
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 4)
                        {
                            environment.Add(values[0]);
                            application.Add(values[1]);
                            serverrole.Add(values[2]);
                            servers.Add(values[3]);
                        }
                    }
                }
            }
