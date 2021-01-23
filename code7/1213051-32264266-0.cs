    using System.Data;
    ...
    foreach (DataColumn dc in dataGridView1.Columns)
    {
        colNames[col++] = dc.ColumnName;
    }
