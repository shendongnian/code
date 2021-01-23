    // Don't throw an exception when we're done.
    e.ThrowException = false;
    // Display an error message.
    string txt = "Error with " +
        dgvPeople.Columns[e.ColumnIndex].HeaderText +
        "\n\n" + e.Exception.Message;
    MessageBox.Show(txt, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    // If this is true, then the user is trapped in this cell.
    e.Cancel = false;
