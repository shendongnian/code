    this.dataGridView1.Columns.Clear();
    this.dataGridView1.AutoGenerateColumns = false;
    //Create Column
    var column1 = new DataGridViewTextBoxColumn()
    {
        Name = "firstNameColumn",        /*Name of Column*/
        HeaderText = "First Name",       /*Title of Column*/
        DataPropertyName = "FirstName"   /*Name of the property to bind to cilumn*/
    };
    //Add column to grid
    this.dataGridView1.Columns.Add(column1);
   
