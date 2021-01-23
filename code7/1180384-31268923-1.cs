    private void gridGeregistreerd_ColumnButtonClick(object sender, ColumnActionEventArgs e)
    {
        var dialog = new Bevestiging();
        if (DialogResult.OK != dialog.ShowDialog())
        {
            int aantal = dialog.Aantal;
            /* Save it to database or whatever you want */
        }
    }
