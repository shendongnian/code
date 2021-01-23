    private void ClearButton()
    {
        foreach (var control in this.Controls)
        {
            Button btn = control as Button;
            if (btn != null)
            {
                btn.Text = string.Empty;
            }
        }
    }
