    void Main()
    {
        var f = new Form {Text = "Excel SaveAs sample"};
        var b = new System.Windows.Forms.Button {Text="Save as xls", AutoSize = true};
        var dgv = new DataGridView {Top=60};
        
        var tbl = new System.Data.DataTable();
        new SqlDataAdapter(
          "select CustomerId, CompanyName, ContactName from Customers", 
          @"server=.\SQLExpress;Database=Northwind;Trusted_Connection=yes")
          .Fill( tbl );
        
        dgv.DataSource = tbl;
        
        f.Controls.Add( b );
        f.Controls.Add( dgv );
        
        b.Click += (sender, args) => {
          var xl = new Microsoft.Office.Interop.Excel.Application();
          var wb = xl.Workbooks.Add();
          var sheet = (Worksheet)wb.ActiveSheet;
          
          for (int i = 0; i < dgv.Columns.Count; i++)
          {
            ((Range)sheet.Cells[1,i+1]).Value = dgv.Columns[i].HeaderText;
          }
          
          for (int i = 0; i < tbl.Rows.Count; i++)
          {
            for (int j = 0; j < tbl.Columns.Count; j++)
            {
              ((Range)sheet.Cells[i+2,j+1]).Value = dgv.Rows[i].Cells[j].Value.ToString();         
            }
          }
          xl.DisplayAlerts = false;
          wb.SaveAs(@"d:\temp\abc.xls");
          xl.Quit();
          MessageBox.Show("Saved");
        };
        
        f.Show();
    }
