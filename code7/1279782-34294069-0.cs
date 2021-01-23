    void RunChecks()
    {
        ...
        SetQueryText(sQuery); // instead of txtSql.Text = sQuery;
        ...
    }
    delegate void SetTextDelegate(string text);
    void SetQueryText(string query)
    {
        if (txtSql.InvokeRequired)
        {
            txtSql.BeginInvoke(new SetTextDelegate(SetQueryText), query);
            return;
        }
        txtSql.Text = query;
    }
