            var p = new WebProxy("Scheme://Host:Port", true, new[] { "" }, new NetworkCredential("login", "pass"));
            var p1 = new WebProxy("Scheme://Host:Port", true, new[] { "" }, new NetworkCredential("login", "pass"));
            var p2 = new WebProxy("Scheme://Host:Port", true, new[] { "" }, new NetworkCredential("login", "pass"));
            wb1 = ChromeTest.Create(p1, b => b.Load("http://speed-tester.info/check_ip.php"));
            groupBox1.Controls.Add(wb1);
            wb1.Dock = DockStyle.Fill;
            
            wb2 = ChromeTest.Create(p2, b => b.Load("http://speed-tester.info/check_ip.php"));
            groupBox2.Controls.Add(wb2);
            wb2.Dock = DockStyle.Fill;
            wb3 = ChromeTest.Create(p, b => b.Load("http://speed-tester.info/check_ip.php"));
            groupBox3.Controls.Add(wb3);
            wb3.Dock = DockStyle.Fill;
