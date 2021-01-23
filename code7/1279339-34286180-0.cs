    string line;
    while ((line = await streamReader.ReadLineAsync()) != null)
    {
      if (line.StartsWith("ERROR:")) tbxLog.AppendLine(line);
      if (line.StartsWith("CRITICAL:"))
      {
        if (MessageBox.Show(line + "\r\n" + "Do you want to continue?", 
                            "Critical error", MessageBoxButtons.YesNo) == DialogResult.No)
        {
          return;
        }
      }
      await httpClient.PostAsync(...);
    }
