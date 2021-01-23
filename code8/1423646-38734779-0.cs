    public partial class frmMain : Form
    {
        MySqlConnection conn = null;
        public frmMain()
        {
            InitializeComponent();
        }
        private void mnuConnect_Click(object sender, EventArgs e)
        {
            if (mnuConnect.Text.CompareTo("Connect") == 0)
            {
                String connString = @"Server=127.0.0.1;Database=product_sales_company;Uid=root;Pwd=;";
                try
                {
                    conn = new MySqlConnection(connString);
                    conn.Open(); // Membuka koneksi
                    mnuEmployee.Enabled = true;
                    mnuConnect.Text = "Disconnect";
                    lblStatusKoneksi.Text = "Connected";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (conn != null)
                {
                    conn.Close(); // Menutup koneksi
                    conn.Dispose();
                }
                foreach (Form form in this.MdiChildren)
                {
                    form.Close();
                }
                mnuEmployee.Enabled = false;
                mnuConnect.Text = "Connect";
                lblStatusKoneksi.Text = "Disconnected";
            }
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                conn.Close(); // Menutup koneksi
                conn.Dispose();
            }
            Application.Exit();
        }
        private void mnuList_Click(object sender, EventArgs e)
        {
            // Cek apakah form yang memiliki jenis form yang sama (frmDaftarEmployee) sudah ada yang terbuka
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmDaftarEmployee))
                {
                    form.Activate(); // Membuat form yang ditunjuk menjadi aktif
                    return;
                }
            }
            frmDaftarEmployee formDafarEmployee = new frmDaftarEmployee(conn);
            formDafarEmployee.MdiParent = this;
            formDafarEmployee.Show();
        }
    }
}
