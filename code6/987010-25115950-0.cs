    DataView cView = result.DefaultView;
    StringBuilder sb = new StringBuilder();
    bool first = true;
    foreach (string items in existingSites)
    {
        if (first)
        {
            first = false;
        }
        else
        {
            sb.Append(" AND ");
        }
        sb.AppendFormat("Sites <> '{0}'");
    }
    cView.RowFilter = sb.ToString();
    dgvResult.DataSource = cView;
