    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var zone in TimeZoneInfo.GetSystemTimeZones())
            {
                cbTimeZones.Items.Add(zone.Id);
            }
        }
        private void cbTimeZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(((ComboBox)sender).SelectedItem.ToString());
            lblTimeZone.Text = zone.StandardName;
        }
    }
