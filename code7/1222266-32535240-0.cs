    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace DataGridViewRichTextBox
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                LoadDatGridView();
            }
    
            private readonly DataTable _table = new DataTable();
            private void LoadDatGridView()
            {
                _table.Columns.Add("Column1");
                _table.Rows.Add("CDTRS1 2015/9/14 BR01");
                _table.Rows.Add("CDTRS2 2015/9/15 BR02");
                _table.Rows.Add("CDTRS2 2015/9/15 BR03");
                _table.AcceptChanges();
                
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _table;
    
                foreach (DataRow row in _table.Rows)
                {
                    var splits = row[0].ToString().Split(' ');
                    var value = string.Format("{0} {1}", splits[0], splits[1]);
                    if (IsValueExist(value))
                    {
                        using (var rich = new RichTextBox())
                        {
                            rich.Text = row[0].ToString();
                            rich.Select(0, value.Length);
                            rich.SelectionColor = Color.Brown;
                            row[0] = rich.Rtf;
                        }
                    }
                }
                _table.AcceptChanges();
            }
    
            private bool IsValueExist(string value)
            {
                return dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => row.Cells[0].Value.ToString().Contains(value));
            }
        }
    }
