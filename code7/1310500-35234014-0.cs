        using (StreamWriter sw = new StreamWriter("pippo.csv", true))
        {
            sw.WriteLine(string.Format("{0};{1};{2}", DateTime.Now, "Google Perf Test", ws1.Elapsed));
            sw.WriteLine(string.Format("{0};{1};{2}", DateTime.Now, "Facebook Perf Test", ws2.Elapsed));
        }
