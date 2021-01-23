        List<IISLogEvent> logs = new List<IISLogEvent>();
        using (ParserEngine parser = new ParserEngine([filepath]))
        {
            while (parser.MissingRecords)
            {
                logs = parser.ParseLog().ToList();
            }
        }
