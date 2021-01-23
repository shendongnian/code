        public partial class Form1 : Form
    {
        string cmbRFR_item;
        public Form1()
        {
            InitializeComponent();
        }
        private void change_cmbSubRFR_items()
        {
            cmbSubRFR.Items.Clear();
            switch (cmbRFR_item)
            {
                case "Null":
                    cmbSubRFR.Items.Add("Null/a blank item");
                    cmbSubRFR.Text = "Null/a blank item";
                    break;
                case "POSITIONING":
                    cmbSubRFR.Items.Add("Anatomy cut-off");
                    cmbSubRFR.Items.Add("Rotation");
                    cmbSubRFR.Items.Add("Obstructed view");
                    cmbSubRFR.Items.Add("Tube or grid centering");
                    cmbSubRFR.Items.Add("Motion");
                    cmbSubRFR.Text = "";
                    break;
                case "ARTEFACT":
                    cmbSubRFR.Items.Add("ARTEFACT");
                    cmbSubRFR.Text = "ARTEFACT";
                    break;
                case "PATIENT ID":
                    cmbSubRFR.Items.Add("Incorrect Patient");
                    cmbSubRFR.Items.Add("Incorrect Study/Side");
                    cmbSubRFR.Items.Add("User Defined Error");
                    cmbSubRFR.Text = "";
                    break;
                case "EXPOSURE ERROR":
                    cmbSubRFR.Items.Add("Under Exposure");
                    cmbSubRFR.Items.Add("Over Exposure");
                    cmbSubRFR.Items.Add("Exposure Malfunction");
                    cmbSubRFR.Text = "";
                    break;
                case "TEST IMAGES":
                    cmbSubRFR.Items.Add("Quality Control");
                    cmbSubRFR.Items.Add("Service/Test");
                    cmbSubRFR.Text = "";
                    break;
            }
        }
        private void cmbRFR_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbRFR_item!= cmbRFR.SelectedItem.ToString())
            {
                cmbRFR_item = cmbRFR.SelectedItem.ToString();
                change_cmbSubRFR_items();
            }
        }
    }
