    var csvFileLenth = new System.IO.FileInfo(path).Length;
    if( csvFileLenth != 0)
    {
      try
      {
        while (csv.Read())
        {
          // process the CSV file...
        }
      }
      catch (CsvReaderException)
      {
        // Handles this error (when attempting to call "csv.Read()" on a completely empty CSV):
        // An unhandled exception of type 'CsvHelper.CsvReaderException' occurred in CsvHelper.dll
        // Additional information: No header record was found.
        MessageBox.Show(MessageBoxErrorMessageExpectedColumns,              MessageBoxErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
      }
    }
