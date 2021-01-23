    BeginInvoke((Action)(() =>
    { 
      // for example 
        var Code = new DataGridViewTextBoxColumn()
                    {
                        Width = 50,
                        DataPropertyName = "Code",
                        DefaultCellStyle = new DataGridViewCellStyle()
                        {
                            Alignment = DataGridViewContentAlignment.MiddleLeft,
                            ForeColor = Color.Black,
                        },
                        HeaderCell = new DataGridViewColumnHeaderCell()
                        {
                            Style = new DataGridViewCellStyle()
                            {
                                Alignment = DataGridViewContentAlignment.MiddleCenter,
                            }
                        }
                    };
                    Code.HeaderText = "Code";
                    dgvWorkTypes.Columns.Add(Code); 
    
    }));
