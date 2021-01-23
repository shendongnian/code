    if (radbtnBar.Checked)
    {
        MessageBox.Show(advanceToBlackBar);
        PrintUtils.SendCommandToPrinter(advanceToBlackBar);
    }
    else if (radbtnGap.Checked)
    {
        MessageBox.Show(advanceToGap);
        PrintUtils.SendCommandToPrinter(advanceToGap);
    }
