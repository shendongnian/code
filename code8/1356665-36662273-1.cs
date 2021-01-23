    db.TableName.Select(m => new MyClass 
    {
        Username = m.Username,
        Message = m.Message,
        Subject = m.Subject
    });
