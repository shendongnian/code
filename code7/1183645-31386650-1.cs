    var query = context.Students
                       .Include(s => s.Standard)
                       .Select(s => new DataBindingProjection
                        {
                           StudentName = s.StudentName,
                           DateOfBirth = s.DateOfBirth,
                           Height = s.Height,
                           Weight = s.Weight,
                           ...
                           StandardName = s.Standard.StandardName
                        };
    
    dataGridView1.DataSource = query.ToList();
    dataGridView1.Columns[1].DataPropertyName = "StudentName";
    dataGridView1.Columns[2].DataPropertyName = "DateOfBirth";
    dataGridView1.Columns[3].DataPropertyName = "Height";
    dataGridView1.Columns[4].DataPropertyName = "Weight";
    dataGridView1.Columns[5].DataPropertyName = "StandardName";
