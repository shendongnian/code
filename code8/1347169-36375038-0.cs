            WebClient myClient = new WebClient();
            Stream response = myClient.OpenRead("http://yahoo.com");
            StreamReader reader = new StreamReader(response);
            string source = reader.ReadToEnd();
            var parser = new HtmlParser();
            var document = parser.Parse(source);
            var p = document.QuerySelector("p");    
            // I used 'p' instead of 'strong' because there's no
            //strong on that page
            MessageBox.Show(p.TextContent); // Display text
            response.Close();
