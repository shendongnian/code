    public BindingList<Data> DataList { get; set; }
    public void Load()
    {
        DataList = new BindingList<Data>
                       {
                            new Data
                                {
                                    Key = "Key1",
                                    Value = "Value1"
                                },
                            new Data
                                {
                                    Key = "Key2",
                                    Value = "Value2"
                                },
                            new Data
                                {
                                    Key = "Key3",
                                    Value = "Value3"
                                }
                        };
         listBox1.DataSource = DataList;
         listBox1.DisplayMember = "Value";
         listBox1.ValueMember = "Key";
    }
    public class Data
    {
         public string Key { get; set; }
         public string Value { get; set; }
    }   
    private void button1_Click(object sender, EventArgs e)
    {
        DataList.RemoveAt(1);
    }
