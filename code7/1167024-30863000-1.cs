    public class SharedData
    {
       public SomeValue1 { get; set; }
       public SomeValue2 { get; set; }
       public SomeValue3 { get; set; }
    }
    public partial class Form1 : Form
    {
        private SharedData _data;
        public Form1()
        {
            _data = new SharedData();
            var form2 = new Form2(_data);
        }
    }
    public partial class Form2 : Form
    {
        private SharedData _data;
        public Form2(SharedDatadata data)
        {
            _data = data;
        }
    }
