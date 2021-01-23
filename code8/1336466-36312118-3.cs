    var column1 = new DataGridViewCheckBoxColumn();   
    column1.Name = "column1";                         //Name of column
    column1.HeaderText= "Is Approved";                //Title of column
    column1.DataPropertyName = "approvation";         //Name of field in database
    column1.TrueValue = "APPROVED";                   //True value
    column1.FalseValue = "NOTAPPROVED";               //False Value
    this.dataGridView1.Columns.Add(column1);
