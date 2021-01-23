    static void Main(string[] args)
        {
            string textBox1_Text = "";
            string textBox2_Text = "";
            string textBox3_Text = "";
            var list1 = textBox1_Text.Split(Environment.NewLine.ToCharArray()).ToList();
            var list2 = textBox2_Text.Split(Environment.NewLine.ToCharArray()).ToList();
            var list3 = textBox3_Text.Split(Environment.NewLine.ToCharArray()).ToList();
            var largestListSize = list1.Count > list2.Count ? list1.Count : list2.Count;
            largestListSize = list3.Count > largestListSize ? list3.Count : largestListSize;
            var sb = new StringBuilder();
            for (int i = 0; i < largestListSize; i++)
            {
                var list1Line = list1.Count <= i ? list1[i] : string.Empty;
                var list2Line = list1.Count <= i ? list2[i] : string.Empty;
                var list3Line = list1.Count <= i ? list3[i] : string.Empty;
                sb.AppendFormat(@"""{0}""\t""{1}""\t""{2}""", list1Line, list2Line, list3Line);
            }
            System.IO.File.WriteAllText("your_path", sb.ToString());
        }
