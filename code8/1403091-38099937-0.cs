    comboBox1.Items.AddRange(langerlist.ToArray());
    comboBox1.DisplayMember = "Name";
    comboBox1.ValueMember = "ID";
    public class MyClass
    {
        public string Name { set; get; }
        public string ID { set; get; }
    }
