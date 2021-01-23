    public partial class Form2 : Form
    {
        private MyClass one;
        private Label label1;
        private ComboBox comboBox1;
        private FlowLayoutPanel panel;
        private Button btn1;
        public Form2()
        {
            InitializeComponent();
            one = new MyClass();
            panel = new FlowLayoutPanel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            btn1 = new Button();
            btn1.Text = "Click to change Property";
            btn1.Click += (sender, args) => { one.A_Value = MyEnum.BtnVal; }; // to test binding to the property
            panel.Dock = DockStyle.Fill;
            Controls.Add(panel);
            panel.Controls.Add(comboBox1);
            panel.Controls.Add(label1);
            panel.Controls.Add(btn1);
            comboBox1.SelectedIndexChanged += (sender, args) =>
            {
                one.A_Value = (MyEnum)(sender as ComboBox).SelectedItem; // update the object when the ComboBox is changed
            };
            comboBox1.DataSource = Enum.GetValues(typeof(MyEnum));
            comboBox1.DataBindings.Add("SelectedItem",one,"A_Value"); // update the ComboBox if the Property is changed by something else
            label1.DataBindings.Add("Text",one,"A_Value"); // to show that changes happen to the property and not just the ComboBox
        }
    }
    public enum MyEnum
    {
        [Description("SomeVal")]
        SomeVal,
        [Description("AnotherVal")]
        AnotherVal,
        [Description("OneMoreVal")]
        OneMoreVal,
        [Description("ButtonClickedValue")]
        BtnVal
    }
    public class MyClass : INotifyPropertyChanged
    {
        private MyEnum whatever;
        public MyEnum A_Value
        {
            get { return whatever; } 
            set { whatever = value;
                PropertyChanged(this, new PropertyChangedEventArgs("A_Value"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
