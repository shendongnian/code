    public enum CampaignMode { Normal, AxTest };
    public partial class DemoForm : Form
    {
        private CampaignMode campaignMode;
        public DemoForm(CampaignMode mode)
        {
            InitializeComponent();
            campaignMode = mode;
            SetControlsVisibility();
        }
        private void SetControlsVisibility()
        {
            if (campaignMode == CampaignMode.Normal)
            {
                //Set normal controls visible;
                //Set axtest controls invisible;
            }
            else
            {
                //Set normal controls invisible;
                //Set axtest controls visible;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (campaignMode == CampaignMode.Normal)
            {
                MethodA();                
            }
            else
            {
                MethodB();
            }
        }
        private void MethodA()
        {
        }
        private void MethodB()
        {
        }
    }
