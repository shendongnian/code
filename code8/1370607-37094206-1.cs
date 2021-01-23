    private void LoadRecords()
    {
        soldTickets =
            File
                .ReadAllLines(FILENAME)
                .Select(line =>
                {
                    string[] data = line.Split(DELIM);
                    return
                        new Record()
                        {
                            Name = data[0],
                            Tickets = data[1],
                            Purchase = data[2],
                            Date = data[3]
                        };
                })
                .OrderBy(record => record.Name)
                .ToArray();
        currentRecordIndex = -1;
    }
