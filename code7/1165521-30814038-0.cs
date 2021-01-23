     foreach (View tp in MainView.Views)
        {
            foreach (Control textboxy in tp.Controls)
            {
                if(textboxy is TextBox)
                {
                    if((textboxy as TextBox).Enabled)
                    {
                        if (!string.IsNullOrWhiteSpace((textboxy as TextBox).Text))
