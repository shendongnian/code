            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla /5.0 (Compatible MSIE 9.0;Windows NT 6.1;WOW64; Trident/5.0)");
                string res = client.DownloadString("http://limun.hr/main.aspx?id=18");
                Console.WriteLine(res);
            }
