        private void Form1_Load(object sender, EventArgs e)
        {
            // This will change the ListBox behaviour, so you can customize the drawing of each item on the list.
            // The fixed mode makes every item on the list to have a fixed size. If you want each item having
            // a different size, you can use DrawMode.OwnerDrawVariable.
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            // Here we define the height of each item on your list.
            listBox1.ItemHeight = 40;
            // Here i will just make an example data source, to emulate the control you are trying to reproduce.
            var dataSet = new List<Tuple<string, string>>();
            dataSet.Add(new Tuple<string, string>("5:30 PM - 6:00 PM", "11 avaliable rooms"));
            dataSet.Add(new Tuple<string, string>("6:00 PM - 6:30 PM", "12 available rooms"));
            listBox1.DataSource = dataSet;
        }
