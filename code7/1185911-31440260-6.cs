    public class RowObject
    {
        public DateTime date;
        public string price;
    }
    
    List<RowObject> m_rowData;
    // A delegate that can take the RowObject
    private void ProcessorDelegate(string value, RowObject currentRow);
    // Pass in the RowObject to your processors
    // The processor updates the RowObject with the processed information.
    private void DateProcessor(string value, RowObject currentRow)
    {
        // Make sure 'value' is a date
        DateTime date;
        if (!DateTime.TryParse(value, out date))
        {
            // If this field is required you could throw an exception here, or output a console error.
            // This is the point at which you could check if 'value' was null or empty.
            return;
        }
        
        // 'value' was a date, so set this row's date
        currentRow.date = date;
    }
