    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var zone in TimeZoneInfo.GetSystemTimeZones())
            {
                cbTimeZones.Items.Add(zone.DisplayName);
            }
        }
        private void cbTimeZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var zone = TimeZoneInfo.GetSystemTimeZones().Single(x => x.DisplayName == ((ComboBox)sender).SelectedItem.ToString());
            lblTimeZone.Text = TimeZoneInfo.FindSystemTimeZoneById(zone.Id).StandardName;
        }
    }
