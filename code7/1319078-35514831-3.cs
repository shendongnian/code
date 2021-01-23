    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Demos
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			dg.AllowUserToAddRows = dg.AllowUserToDeleteRows = false;
    			var colId = new DataGridViewTextBoxColumn { HeaderText = "Id", ReadOnly = true };
    			var colName = new DataGridViewTextBoxColumn { HeaderText = "Name" };
    			var colCity = new DataGridViewComboBoxColumn { HeaderText = "City" };
    			var colAction = new DataGridViewButtonColumn { HeaderText = "Action" };
    			colName.ReadOnly = true;
    			colCity.ReadOnly = true;
    			colCity.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    			colAction.Text = "Edit";
    			dg.Columns.AddRange(colId, colName, colCity, colAction);
    			var data = new[]
    			{
    				new { Id = 1, Name = "Mitch", City = "Kolkata" },
    				new { Id = 2, Name = "Simon", City = "Delhi" },
    				new { Id = 3, Name = "Poly", City = "Madras" },
    			};
    			colCity.Items.AddRange(data.Select(item => item.City).Distinct().ToArray());
    			foreach (var item in data)
    				dg.Rows.Add(item.Id, item.Name, item.City, "Edit");
    			Action<DataGridViewRow> enterEditMode = row =>
    			{
    				var cellName = (DataGridViewTextBoxCell)row.Cells[colName.Index];
    				var cellCity = (DataGridViewComboBoxCell)row.Cells[colCity.Index];
    				var cellAction = (DataGridViewButtonCell)row.Cells[colAction.Index];
    				cellName.ReadOnly = false;
    				cellCity.ReadOnly = false;
    				cellCity.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
    				dg.CurrentCell = cellName;
    				dg.BeginEdit(true);
    				cellAction.Value = "Save";
    			};
    			Action<DataGridViewRow> exitEditMode = row =>
    			{
    				var cellName = (DataGridViewTextBoxCell)row.Cells[colName.Index];
    				var cellCity = (DataGridViewComboBoxCell)row.Cells[colCity.Index];
    				var cellAction = (DataGridViewButtonCell)row.Cells[colAction.Index];
    				cellName.ReadOnly = true;
    				cellCity.ReadOnly = true;
    				cellCity.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    				cellAction.Value = "Edit";
    			};
    			dg.CellContentClick += (sender, e) =>
    			{
    				if (e.ColumnIndex == colAction.Index)
    				{
    					var row = dg.Rows[e.RowIndex];
    					var cellAction = (DataGridViewButtonCell)row.Cells[colAction.Index];
    					if ((string)cellAction.Value == "Edit")
    						enterEditMode(row);
    					else if (dg.EndEdit())
    					{
    						// Save code goes here ...
    						exitEditMode(row);
    					}
    				}
    			};
    			dg.RowValidated += (sender, e) =>
    			{
    				var row = dg.Rows[e.RowIndex];
    				var cellAction = (DataGridViewButtonCell)row.Cells[colAction.Index];
    				if ((string)cellAction.Value == "Save")
    					exitEditMode(row);
    			};
    			Application.Run(form);
    		}
    	}
    }
