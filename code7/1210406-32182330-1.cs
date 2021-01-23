            private void Form1_Load(object sender, EventArgs e)
            {
                myDataListBindingSource.DataSource = new MyDataList();
            }
    
        public class MyDataList : List<MyData>
        {
            public MyDataList()
            {
                Add(new MyData { ID = 1, Name = "Name 1" });
                Add(new MyData { ID = 2, Name = "Name 2" });
                Add(new MyData { ID = 3, Name = "Name 3" });
                Add(new MyData { ID = 4, Name = "Name 4" });
                Add(new MyData { ID = 5, Name = "Name 5" });
            }
        }
    
     public class MyData
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
