    public partial class Form1 : Form
    {
      private DataTable table;
    
      public Form1()
      {
        this.InitializeComponent();
      
        this.table = new DataTable("Table");
        DataColumn col1 = new DataColumn("Check", typeof(bool));
        DataColumn col2 = new DataColumn("Text", typeof(string));
        this.table.Columns.Add(col1);
        this.table.Columns.Add(col2);
          
        this.table.ReadXml("test.xml");
        this.dataGridView1.DataSource = this.table;
      }
      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
        this.table.WriteXml("test.xml");
      }
    }
