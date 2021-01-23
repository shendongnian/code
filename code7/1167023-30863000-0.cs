    public class InputData
    {
       public SomeValue1 { get; set; }
       public SomeValue2 { get; set; }
       public SomeValue3 { get; set; }
    }
    public partial class Form2 : Form
    {
        public Form2(InputData data)
        {
            //...
        }
    }
