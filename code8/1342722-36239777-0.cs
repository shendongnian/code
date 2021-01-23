            //...
            timer1.Interval = 1000; // 1 sec interval.
            timer1.Start();
            RestClient client = new RestClient("http://127.0.0.1/")
                                {
                                    Timeout = 10 * 1000 //10 sec timeout time.
                                };
            
            RestRequest request = new RestRequest("/test/{FileName}");
            request.AddParameter("FileName", "testFile.abc", ParameterType.UrlSegment);
            string path = @"C:/Users/[user]/Desktop/testFile.abc";
            
            var fileForDownload = client.DownloadData(request);
            fileForDownload.SaveAs(path);
            if (File.Exists(@"C:/Users/[user]/Desktop/testFile.abc"))
            {
                MessageBox.Show("done");
            }
            progressBar1.Value = 100;
            timer1.Stop();
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 100)
            {
                progressBar1.Value += 10;
            }
            if (progressBar1.Value >= 100)
            {
                progressBar1.Value = 0;
            }
        }
