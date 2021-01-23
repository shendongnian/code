    private void UpdateChart()
    {
        for (int i = 0, count = itsDAQ.getStreamCount(); i < count; i++)
        {
            Chart1DataSource.AppendAsync(itsDAQ.getValue());
            if(Chart1DataSource.Collection.Count >= 300)// this part should work in a thread-safe
            { Chart1DataSource.Collection.RemoveAt(0); }// context and with some precaution 
        }
    }
