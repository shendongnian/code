        public partial class Form1 : Form
    {
        private List<Conversion> conversions=new List<Conversion>();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            loadconversions();
            //foreach (Conversion c in conversions)
            //{this.comboBox1.Items.Add(c); }
            comboBox1.DataSource = conversions;
            this.comboBox1.DisplayMember = "GetCmboBxText";
        }
        private void loadconversions()
        {
            fillconversions("feet","yards",3);
            fillconversions("yard", "feet", 0.33m);
            fillconversions("km", "mile", 0.54m);
            fillconversions("mile", "km", 1.6m);
            fillconversions("quarts", "gallons", 4);
        }
        private void fillconversions(string from, string to, decimal multiplier)
        {
            conversions.Add(new Conversion(from, to, multiplier));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conversion c = (Conversion)this.comboBox1.SelectedItem;
            this.textBox1.Text = c.GetDisplayText;
        }
    }
    public class Conversion
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Multiplier { get; set; }
        public Conversion(string from, string to, decimal multiplier)
        {
            From = from;
            To = to;
            Multiplier = multiplier;
        }
        public string GetDisplayText
        {
            get { return From + ("|") + To + ("|") + Multiplier; }
        }
        public string GetCmboBxText
        {
            get
            {
                return From + (" to ") + To;
            }
        }
    }
