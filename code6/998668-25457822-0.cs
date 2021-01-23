        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FetchData();
        }
        private void FetchData()
        {
            List<Site> sites = new List<Site>();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, e2) =>
            {
                dynamic conn = AutomationFactory.CreateObject("ADODB.Connection");
                conn.ConnectionString =
                    @"Provider=sqloledb;
                  Data Source=.\SQLEXPRESS;
                  Initial Catalog=SamDb;
                  Integrated Security=SSPI";
                conn.Open();
                dynamic recordSet = conn.Execute("SELECT SiteId, SiteName FROM Sites");
                recordSet.MoveNext();
                while (!recordSet.EOF)
                {
                    string siteName = (string)recordSet.Fields.Item(1).Value;
                    short siteId = (short)recordSet.Fields.Item(0).Value;
                    sites.Add(new Site(SiteId: siteId, SiteName: siteName));
                    recordSet.MoveNext();
                }
            };
            worker.RunWorkerCompleted += (s, e2) =>
            {
                this.ListSites.ItemsSource = sites;
            };
            worker.RunWorkerAsync();
        }
