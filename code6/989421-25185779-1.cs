    // The list of objects
    List<Fruit> fruit = new List<Fruit>( ) 
        {new Fruit("Apple",Color.Red), 
         new Fruit("Orange",Color.Orange), 
         new Fruit("Pear",Color.Green)}; 
    
    BindingSource source = new BindingSource(fruit, null);
    dataGridView1.AutoGenerateColumns = false;
    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
    column.HeaderText = "Name Of Fruit";
    column.DataPropertyName = "Name"; // Name of the property in Fruit
    dataGridView1.Columns.Add(column);
    DataGridViewTextBoxColumn colorColumn = new DataGridViewTextBoxColumn();
    colorColumn.HeaderText = "Color";
    colorColumn.DataPropertyName = "Color"; // Name of the property in Fruit
    dataGridView1.Columns.Add(colorColumn);
    dataGridView1.DataSource = source;
