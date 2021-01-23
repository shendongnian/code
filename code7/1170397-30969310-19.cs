    string installId = getOfflineInstallId();
    StringBuilder sb = new StringBuilder();
    bool fRun = false;
    for (int i = 0; i < installId.Length; i++)
    {
        if (i % 7 == 0)
        {
            if (fRun)
                sb.Append('-');
            else
                fRun = true; //Stops a '-' being added at the 1st position.
        }
        sb.Append(installId[i]);
    }
    idTextBox.Text = sb.ToString();
