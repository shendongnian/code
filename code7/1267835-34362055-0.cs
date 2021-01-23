     public URLTester1()
        {
            InitializeComponent();
        }
        //Web Page Active?
        private void button1_Click(object sender, EventArgs e)
        {
            Uri fileURI = new Uri(URLbox1.Text);
            //tests http response 
            WebRequest request = WebRequest.Create(fileURI);
            HttpWebResponse response = null;
            request.Method = "HEAD";
            bool exists = false;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                exists = response.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                exists = false;
            }
            finally
            {
                // close your response.
                if (response != null)
                    response.Close();
            }
            if (exists)
            {
                label1.Text = "Active";
            }
            else
            {
                label1.Text = "Inactive";
            }
