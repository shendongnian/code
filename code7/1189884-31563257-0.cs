    public FieldViewer GetFieldViewByFieldIDIPAndUserByDate( int fieldID, string ip, string userID, DateTime date )
    {
        return this.context.FieldViewers.Where( x =>
                x.Field.FieldID == fieldID &&
                x.Viewer.IPAddress == ip &&
                x.Viewer.User.Id == userID)
           .AsEnumerable()
           .Where(x => date.Subtract( x.Viewer.CreatedAt ).TotalMinutes >= 10)
           .FirstOrDefault();  
    }
