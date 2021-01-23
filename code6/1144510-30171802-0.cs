    if(!String.IsNullOrEmpty(DateGridView1.Rows[selectedRow].Cells[2].Value.ToString())
    {
    DateTime dateTime = DateGridView1.Rows[selectedRow].Cells[2].Value;
    if (dateTime > DateTimePicker1.MinValue && dateTime < DateTimePicker1.MaxValue)
    {
                    DateTimePicker1.Value = (DateTime)DateGridView1.Rows[selectedRow].Cells[2].Value;
    }
    }
