    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    
    			var form = new Form();
    			var comboBox = new ComboBox { Left = 16, Top = 16, DropDownStyle = ComboBoxStyle.DropDownList };
    			var textBoxID = new TextBox { Left = 16, Top = comboBox.Bottom + 8 };
    			var textBoxName = new TextBox { Left = 16, Top = textBoxID.Bottom + 8 };
    			var textBoxPhone = new TextBox { Left = 16, Top = textBoxName.Bottom + 8 };
    			form.Controls.AddRange(new Control[] { comboBox, textBoxID, textBoxName, textBoxPhone });
    
    			// Begin essential part
    			var dataSource = GetData();
    
    			textBoxID.DataBindings.Add("Text", dataSource, "ID");
    			textBoxName.DataBindings.Add("Text", dataSource, "Name");
    			textBoxPhone.DataBindings.Add("Text", dataSource, "Phone");
    
    			comboBox.DisplayMember = "Name";
    			comboBox.ValueMember = "ID";
    			comboBox.DataSource = dataSource;
    
    			// End essential part
    			Application.Run(form);
    		}
    
    		static DataTable GetData()
    		{
    			//DataSet dsSet = new DataSet();
    			//dsSet.ReadXml("E:\\baza\\spis_klientow.xml");
    			//return dsSet.Tables["spis_klientow"];
    
    			var table = new DataTable();
    			table.Columns.Add("ID", typeof(int));
    			table.Columns.Add("Name");
    			table.Columns.Add("Phone");
    			for (int i = 1; i <= 10; i++)
    				table.Rows.Add(i, "Name" + i, "Phone" + i);
    			return table;
    		}
    	}
    }
