    for (int i = 0; i < listBox2.Items.Count; i++)
    {
        if (i == 0)
        {
            sb.Append("Select * from ToolsBar where BarcodeValue in (");
            sb.Append("'" + listBox2.Items[i] + "'");
        }
        else
        {
            sb.Append(",'" + listBox2.Items[i] + "'");
        }
    }
    sb.Append(")");
