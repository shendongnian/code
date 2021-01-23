    if (ClickCount > dt.Rows.Count)
    {
        btnNext.Enabled= false;
        // Also with a message
    }
    else
    {
        btnNext.Enabled= true;
        txtNextStep.Text = dt.Rows[ClickCount - 1]["NextStep"].ToString();
    }
