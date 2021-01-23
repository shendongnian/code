    private void MoveValuesToNewDbDeleteFromSourceDb(string valuesType, string values)
    {
        progressReporter.ReportProgress(() => {
            label.text = string.Format("Moving values of type {0}...", valuesType);
        });
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            // Do your move values thing.
            // Report progress
            progressReporter.ReportProgress(() => {
               // ...
            });
        }
    }
