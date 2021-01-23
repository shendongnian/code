    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    namespace IMPORT
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String MyConString = "SERVER=******;" +
               "DATABASE=db;" +
               "UID=root;" +
               "PASSWORD=pws;" + "Convert Zero Datetime = True";
    private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.ShowDialog();
            openfiledialog1.Filter = "allfiles|*.xls";
            txtfilepath.Text = openfiledialog1.FileName;
        }
    private void btnUpload_Click(object sender, EventArgs e)
    {
     string path = txtfilepath.Text;
            string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties = Excel 8.0";
            DataTable Data = new DataTable();
            using (OleDbConnection conn =new OleDbConnection(ConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM[FILE NAME$]", conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(Data);
                conn.Close();
            }
            string ConnStr = MyConString;
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnStr))
            {
                bulkCopy.DestinationTableName = "TABLE NAME";
                bulkCopy.ColumnMappings.Add("userid", "userid");
                bulkCopy.ColumnMappings.Add("password", "password");
                bulkCopy.ColumnMappings.Add("first_name", "first_name");
                bulkCopy.ColumnMappings.Add("last_name", "last_name");
                bulkCopy.ColumnMappings.Add("user_group", "user_group");
                bulkCopy.WriteToServer(Data);
                MessageBox.Show("UPLOAD SUCCESSFULLY");
            }
         }
     }
