    var cbo = new DataGridViewComboBoxColumn();
    // ...
    cbo.DataPropertyName = <the Db Column Name>;
    cbo.DisplayIndex = <whatever int>;
                   
    // temp List of the enum values
    var Sizes = new List<SampleSize>((SampleSize[])Enum.GetValues(typeof(SampleSize)));
    
    // create a Name-Value pairs List from List<SampleSize>
    cbo.DataSource = Sizes
                     .Select(value => new {Name = value.ToString(), 
                                           Value = (int)value})
                    .ToList();
    cbo.ValueMember = "Value";       // what to store
    cbo.DisplayMember = "Name";      // what to show
    
    dgv1.Columns.Add( cbo );
