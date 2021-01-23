    private void AddComboboxColumn()
    {
     DataGridViewComboBoxColumn ColComboBox = new DataGridViewComboBoxColumn();
     dataGridView1.Columns.Add(ColComboBox );
     ColComboBox.DataPropertyName = "ScoreID";
     ColComboBox.HeaderText = "Category";
     ColComboBox.ValueType = typeof(string);
     ColComboBox.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
     ColComboBox.DisplayIndex = 2;
     ColComboBox.Width = 150;
     ColComboBox.DataSource = oleDs ;
     ColComboBox.DisplayMember = "description";
     ColComboBox.ValueMember = "ScoreID";
     ColComboBox.Name = "ScoreID";
     ColComboBox.DataPropertyName = "ScoreID";
    }
