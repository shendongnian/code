    var history = messages.GroupBy(m => new { m.Title, m.Content }, (group, data) => new HistoryModel()
    {
        Title = group.Title,
        Content = group.Content,
        Files = data.Select(k => new File() 
                                    { 
                                        FileId = k.Fileid, 
                                        FileName = k.FileName
                                    }
                            ).ToList(),
    });
