    namespace ProgressBar {
        public partial class Form1 : DevExpress.XtraEditors.XtraForm {
    
            DataTable workTable;
    
            public Form1() {
                InitializeComponent();
                workTable = new DataTable("Records");
                workTable.Columns.Add("Id", typeof(int));
                workTable.Columns.Add("Data", typeof(String));
            }
    
            //this data varies from 0 to 50,000 rows
            private void LoadData(IProgress<int> progress) {
                for(int i = 0; i < 1001; i++) {
                    System.Threading.Thread.Sleep(5);
                    workTable.Rows.Add(i, String.Format("Record {0}", i));
                    progress.Report(i);
                }
            }
    
            private async void button1_Click(object sender, EventArgs e) {
                var progress = new Progress<int>(
                  i => 
                  {
                    DataTable up = workTable.Clone();
                    this.barEditItem1.EditValue = i;
                  });
                  
                await Task.Run(() => this.LoadData(progress));
                
                gridControl1.DataSource = workTable;
            }
        }
    }
