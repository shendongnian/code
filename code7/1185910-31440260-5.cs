    private void ProcessorDelegate(string value);
    
    Dictionary<int, ProcessorDelegate> m_processorMethods = new Dictionary<int, ProcessorDelegate>
    {
        { 0, DateProcessor },
        { 1, PriceProcessor },
    }
    
    private void DateProcessor(string value)
    {
        // Make sure 'value' is a date
        DateTime date;
        if (!DateTime.TryParse(value, out date))
        {
            // If this field is required you could throw an exception here, or output a console error.
            // This is the point at which you could check if 'value' was null or empty.
            return;
        }
        
        // 'value' was a date, so add it to the DateTime[] array.
        Dates.Add(date);
    }
    int numColumnsExpected = 6;
    var Dates = new List<string>();
    var Prices = new List<double>();
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line.Split(';');
    
        if (values.Count != numColumnsExpected)
        {
             throw new System.Exception("Expected " + numColumnsExpected + " columns, only found " + values.Count + " columns for a row.");
        }
        // Sanity check, you must have a processor for each column
        if (values.Count > m_processorMethods.Count)
        {
             throw new System.Exception("Expected " + numColumnsExpected + " processor methods, only found " + m_processorMethods.Count);
        }
        for (int i = 0; i < values.Count; ++i)
        {
            // Pass the value for a column to the processor that handles
            // data for that column.
            m_processorMethods[i](values[i]);
        }
    } 
       DateTime[] s=Convert.ToDateTime(ListA.toArray());
       double[] o=ListB.toArray();
       object[,] PriceByDate=new object[,]{{s},{o}} ;
    }
