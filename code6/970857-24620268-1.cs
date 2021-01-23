    public class MyRecord
    {
        public bool Availability { get; set; }
        public int Field1 { get; set; }
        public string Field2 { get; set; }
        ...
    }
    MyRecords = new BindingList<MyRecord>();
    foreach (var row in dataSet1)
    {
        MyRecords.Add(new MyRecord { Availability  = false, Field1 = ... });
        MyRecords.Add(new MyRecord { Availability  = false, Field1 = ... });
    }
    dataGridView1.DataSource = MyRecords;
