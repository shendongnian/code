    private void Form1_Load(object sender, EventArgs e)
        {
            MainClass m = new MainClass();
            m.allItems.Add(new MainClass.Items(123, 1, "Daily"));
            m.allItems.Add(new MainClass.Items(123, 1, "Daily"));
            m.allItems.Add(new MainClass.Items(123, 1, "Daily"));
            string json = m.toJson();
            richTextBox1.AppendText(json);
        }
