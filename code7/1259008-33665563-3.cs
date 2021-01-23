    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                using (OleDbConnection _connection = new OleDbConnection())
                {
                    var ConnectionString = new StringBuilder("");
                    ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
                    ConnectionString.Append(@"Extended Properties=dBASE IV;");
                    ConnectionString.Append(@"Data Source=c:\temp;");
                    _connection.ConnectionString = ConnectionString.ToString();
                    _connection.Open();
    
                    using (OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM SLAVE.DBF", _connection))
                    {
                        using (DataSet dsRetrievedData = new DataSet())
                        {
                            da.Fill(dsRetrievedData);
                            dataGridView1.DataSource = dsRetrievedData;
                            dataGridView1.DataMember = dsRetrievedData.Tables[0].TableName;
                        }
                    }
                }
            }
        }
    }
