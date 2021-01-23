    public partial class Form1 : Form
    {
        public System.Data.DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            dt = new System.Data.DataTable();
            string correct = "Brokers México, Intermediario de Aseguro,S.A.";
            string broken = "Brokers MÃ©xico, Intermediario de Aseguro,S.A."; // Get text from database
            dt.Columns.Add("SourceEncoding", typeof(string));
            dt.Columns.Add("TargetEncoding", typeof(string));
            dt.Columns.Add("Result", typeof(string));
            dt.Columns.Add("SourceEncodingName", typeof(string));
            dt.Columns.Add("TargetEncodingName", typeof(string));
            int[] encs = new int[] { 
                 28591 // ISO 8859-1
                ,65000 // UTF-7
                ,65001 // UTF-8
                ,1200 // UTF-16
            };
                
            for (int i = 0; i < encs.Length; ++i)
            {
                for (int j = 0; j < encs.Length; ++j)
                {
                    System.Data.DataRow dr = dt.NewRow();
                    dr["SourceEncoding"] = encs[i];
                    dr["TargetEncoding"] = encs[j];
                    System.Text.Encoding enci = Encoding.GetEncoding(encs[i]);
                    System.Text.Encoding encj = Encoding.GetEncoding(encs[j]);
                    byte[] encoded = enci.GetBytes(broken);
                    string corrected = encj.GetString(encoded);
                    dr["Result"] = corrected;
                    dr["SourceEncodingName"] = enci.BodyName;
                    dr["TargetEncodingName"] = encj.BodyName;
                    if (StringComparer.InvariantCultureIgnoreCase.Equals(correct, corrected))
                        dt.Rows.Add(dr);
                }
            }
            this.dataGridView1.DataSource = dt;
        }
    }
