    namespace ProgressBar
    {
        using System.ComponentModel;
        using System.Data;
        using System.Threading;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
    
        public partial class Form1 : DevExpress.XtraEditors.XtraForm
        {
    
            private DataTable workTable;
            private SynchronizationContext _context;
    
            public Form1()
            {
                InitializeComponent();
    
                this._context = SynchronizationContext.Current;
    
                workTable = new DataTable("Records");
                workTable.Columns.Add("Id", typeof(int));
                workTable.Columns.Add("Data", typeof(String));
            }
            
            private async Task LoadData()
            {
                const int iterations = 1001; //whatever you want...
    
                for (int i = 0; i < iterations; i++)
                {
                    workTable.Rows.Add(i, String.Format("Record {0}", i));
                    this._context.Post(() =>
                    {
                        this.UpdateWorkProgress((int) i /iterations)
                    });
                }
            }
    
            private void UpdateWorkProgress(int percent)
            {
                this.barEditItem1.EditValue = percent;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                await this.LoadData();
                gridControl1.DataSource = workTable;
            }        
        }
    }
