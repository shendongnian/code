    private void MySampleForm_Load(object sender, EventArgs e)
    {
        var states = new DataTable("States");
        states.Columns.Add("Id", typeof(int));
        states.Columns.Add("Name", typeof(string));
        states.Rows.Add(1, "State1");
        states.Rows.Add(2, "State2");
        states.Rows.Add(3, "State3");
        var cities = new DataTable("Cities");
        cities.Columns.Add("Name", typeof(string));
        cities.Columns.Add("Population", typeof(int));
        cities.Columns.Add("StateId", typeof(int));
        cities.Rows.Add("City1", 1000, 1);
        cities.Rows.Add("City1", 1500, 1);
        cities.Rows.Add("City1", 700, 2);
        cities.Rows.Add("City1", 2000, 3);
        var stateColumn = new DataGridViewComboBoxColumn();
        stateColumn.Name = "stateColumn";
        stateColumn.HeaderText = "State";
        stateColumn.DataPropertyName= "StateId";
        stateColumn.ValueMember= "Id";
        stateColumn.DisplayMember= "Name";
        stateColumn.DataSource = states;
        this.dataGridView1.Columns.Add(stateColumn);
        this.dataGridView1.DataSource = cities;
    }
    private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
    {
        e.Row.Cells["stateColumn"].Value = 1;
    }
