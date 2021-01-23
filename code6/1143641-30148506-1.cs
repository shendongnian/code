    public partial class Form1 : Form
    {
        private Class1[] _prova =
        {
            new Class1 { pollo = "<not set 1>" },
            new Class1 { pollo = "<not set 2>" }
        };
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obviously in a more complicated data binding scenario, you might
            // want to be more specific about which binding(s) is(are) being
            // removed, rather than just clearing everything.
            textBox1.DataBindings.Clear();
            label1.DataBindings.Clear();
            // If the user edits the text in the TextBox, the pollo property
            // of the currently-selected object will be immediately updated
            textBox1.DataBindings.Add("Text", _prova[comboBox1.SelectedIndex],
                "pollo", false, DataSourceUpdateMode.OnPropertyChanged);
            // We're never going to change the label1.Text property directly,
            // so the binding doesn't ever need to update the source property.
            label1.DataBindings.Add("Text", _prova[comboBox1.SelectedIndex],
                "pollo", false, DataSourceUpdateMode.Never);
        }
    }
