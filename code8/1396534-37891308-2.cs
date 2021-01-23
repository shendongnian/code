    var cbo = new DataGridViewComboBoxColumn();
    // ...
    cbo.DataPropertyName = <the Db Column Name>;
    cbo.DisplayIndex = <whatever int>;
                       
    // create a Name-Value pairs List from SampleSize[] values
    cbo.DataSource = ((SampleSize[])Enum.GetValues(typeof(SampleSize)))
                     .Select(value => new {Name = value.ToString(), 
                                           Value = (int)value})
                    .ToList();
    cbo.ValueMember = "Value";       // what to store
    cbo.DisplayMember = "Name";      // what to show
    
    dgv1.Columns.Add( cbo );
