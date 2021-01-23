    string[] columnLabels = new string[] { "Column 0", "Column 1", "Column 2", "Column 3", "Column 4", "Column 5" };
      
    foreach (string label in columnLabels)
    {
     DataGridTextColumn column = new DataGridTextColumn();
     column.Header = label;
     column.Binding = new Binding(label.Replace(' ', '_'));
     dtgResults.Columns.Add(column);
    }
    int[] ivalues = new int[] { 0, 1, 2, 3 };
    string[] svalues = new string[] { "A", "B", "C", "D" };
    dynamic row = new ExpandoObject();
    for (int i = 0; i < 6; i++)
    {
     switch (i)
     {
      case 0:
      case 1:
      case 2:
       string str = columnLabels[i].Replace(' ', '_');
       ((IDictionary<String, Object>)row)[str] = ivalues[i];
       break;
       case 3:
       case 4:
       case 5:
        string str2 = columnLabels[i].Replace(' ', '_');
        ((IDictionary<String, Object>)row)[str2] = svalues[i - 3];
        break;
     }
    }
    dtgResults.Items.Add(row);
