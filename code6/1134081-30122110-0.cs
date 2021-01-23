     protected override void OnLoad(EventArgs e)
     {
         base.OnLoad(e);
         AddGrid();
         DataTable table = new DataTable();
         table.Columns.Add("cellphone_number");
         table.Rows.Add("1234567890");
         table.Rows.Add("3214567890");
         table.Rows.Add("9874567890");
         radGridView1.AutoGenerateColumns = false;
         radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
         radGridView1.DataSource = table;
         GridViewMaskBoxColumn maskBoxColumn = new GridViewMaskBoxColumn();
         maskBoxColumn.Name = "Phone";
         maskBoxColumn.FieldName = "cellphone_number";
         maskBoxColumn.HeaderText = "Phone";
         maskBoxColumn.MaskType = MaskType.Standard;
         maskBoxColumn.Mask = "(999) 000-0000";
         radGridView1.MasterTemplate.Columns.Add(maskBoxColumn);
         radGridView1.CellFormatting += radGridView1_CellFormatting;
     }
     void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
     {
         if (e.Column.Name == "Phone")
         {
             e.CellElement.Text = Convert.ToUInt64(e.CellElement.Value).ToString("(###)-###-####");
         }
     }
