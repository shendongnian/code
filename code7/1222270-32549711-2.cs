    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Test
    	{
            static bool EqualKeys(DataGridViewRow x, DataGridViewRow y, string[] keyNames)
            {
                foreach (var keyName in keyNames)
                    if (!Equals(x.Cells[keyName].Value, y.Cells[keyName].Value)) return false;
                return true;
            }
            static bool IsDuplicateRow(DataGridView dg, int rowIndex, string[] keyNames)
            {
                var row = dg.Rows[rowIndex];
                for (int i = rowIndex - 1; i >= 0; i--)
                    if (EqualKeys(row, dg.Rows[i], keyNames)) return true;
                return false;
            }
            static bool IsDuplicateRowCell(DataGridView dg, int rowIndex, int columnIndex, string[] keyNames)
            {
                return keyNames.Contains(dg.Columns[columnIndex].Name) && IsDuplicateRow(dg, rowIndex, keyNames);
            }
            class Data
            {
                public string codetrans { get; set; }
                public string datetrans { get; set; }
                public string codeitem { get; set; }
            }
            [STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var dataSet = new List<Data>
    			{
    				new Data { codetrans="CDTRS1", datetrans ="2015/9/14", codeitem="BR01" },
    				new Data { codetrans="CDTRS2", datetrans ="2015/9/15", codeitem="BR02" },
    				new Data { codetrans="CDTRS2", datetrans ="2015/9/15", codeitem="BR03" },
    				new Data { codetrans="CDTRS2", datetrans ="2015/9/15", codeitem="BR03" },
    				new Data { codetrans="CDTRS2", datetrans ="2015/9/15", codeitem="BR05" },
    			};
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
                var keyNames = new[] { "codetrans", "datetrans", "codeitem" };
    			dg.CellFormatting += (sender, e) =>
    			{
                    if (IsDuplicateRowCell((DataGridView)sender, e.RowIndex, e.ColumnIndex, keyNames))
                        e.CellStyle.ForeColor = Color.Red;
    			};
                dg.CellValueChanged += (sender, e) => ((DataGridView)sender).Invalidate();
    			dg.DataSource = dataSet;
    			Application.Run(form);
    		}
    	}
    }
