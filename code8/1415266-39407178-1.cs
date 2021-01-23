    public override void WriteStart(ODataFeed feed)
    {
    }
    
    private void WriteEntry(ODataEntry entry)
    {
        foreach (var header in this.headers)
        {
            var property = entry.Properties.SingleOrDefault(p => p.Name == header);    
            if (property != null)
            {
                this.context.Writer.Write(property.Value);
            }    
            this.context.Writer.Write(",");
        }    
        this.context.Writer.WriteLine();
    }
