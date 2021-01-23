    public void  button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = GetRESTData("http://localhost:55495/EventService.svc/GetAllEvents");
            }
            catch (WebException webex)
            {
                MessageBox.Show("Es gab so ein Schlamassel! ({0})", webex.Message);
            }
        }
        private JArray GetRESTData(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<JArray>(s);
        }
