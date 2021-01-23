    var httpClient = new HttpClient();
                var text = await httpClient.GetStringAsync(@"http://photo-51.netau.net/changelog");
                StringReader sr = new StringReader(text);
    
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
