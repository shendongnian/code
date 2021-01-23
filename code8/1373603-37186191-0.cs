            List<string> unsortedDates = new List<string>();
            string parts = new StreamReader(@"C:\input.txt").ReadToEnd();
            string[] file = parts.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < file.Length; i++)
            {
                string[] data = file[i].Split(new string[] { "," }, StringSplitOptions.None);
                unsortedDates.Add(data[1]);
            }
            var sortedDatesAscending = unsortedDates.OrderBy(x => DateTime.ParseExact(x, "dd/MM/yyyy", null));
            foreach (string s in sortedDatesAscending)
            {
                sb.AppendLine(s + "<br />");
                Label1.Text = sb.ToString();
            }
