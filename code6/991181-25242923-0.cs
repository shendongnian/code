    namespace IPAddressDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                List<IPAddress> ipAddresses = new List<IPAddress>();
                ipAddresses.Add(new IPAddress(new Byte[] { 127, 0, 0, 1 }));
                ipAddresses.Add(new IPAddress(new Byte[] { 198, 0, 0, 1 }));
                ipAddresses.Add(new IPAddress(new Byte[] { 255, 255, 255, 255 }));
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;
                flp.AutoSize = true;
                flp.FlowDirection = FlowDirection.TopDown;
                flp.WrapContents = false;
                foreach (var ipa in ipAddresses)
                {
                    TableLayoutPanel tlp = new TableLayoutPanel();
                    tlp.AutoSize = true;
                    tlp.Dock = DockStyle.Fill;
                    tlp.RowCount = 0;
                    tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tlp.ColumnCount = 0;
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    Label lbl = new Label();
                    lbl.Dock = DockStyle.Fill;
                    Byte[] ba = ipa.GetAddressBytes();
                    lbl.Text = String.Format("{0}.{1}.{2}.{3}", ba[0], ba[1], ba[2], ba[3]);
                    tlp.Controls.Add(lbl, 0, 0);
                    Button b = new Button();
                    b.Text = "Router";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnRouter_Click;
                    tlp.Controls.Add(b, 1, 0);
                    b = new Button();
                    b.Text = "Switch";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnSwitch_Click;
                    tlp.Controls.Add(b, 2, 0);
                    b = new Button();
                    b.Text = "Steelhead";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnSteelhead_Click;
                    tlp.Controls.Add(b, 3, 0);
                    b = new Button();
                    b.Text = "InPath";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnInPath_Click;
                    tlp.Controls.Add(b, 4, 0);
                    b = new Button();
                    b.Text = "Server";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnServer_Click;
                    tlp.Controls.Add(b, 5, 0);
                    b = new Button();
                    b.Text = "NCAP";
                    b.Dock = DockStyle.Fill;
                    b.Click += btnNCAP_Click;
                    tlp.Controls.Add(b, 6, 0);
                    flp.Controls.Add(tlp);
                }
                this.AutoSize = true;
                this.Controls.Add(flp);
            }
    
            private void btnRouter_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked the Router button!");
            }
    
            private void btnSwitch_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked the Switch button!");
            }
    
            private void btnSteelhead_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked the Steelhead button!");
            }
    
            private void btnInPath_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked the InPath button!");
            }
    
            private void btnServer_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked the Server button!");
            }
    
            private void btnNCAP_Click(Object sender, EventArgs e)
            {
                MessageBox.Show("You clicked NCAP the button!");
            }
        }
    }
