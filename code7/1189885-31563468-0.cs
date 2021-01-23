    public FieldViewer GetFieldViewByFieldIDIPAndUserByDate( int fieldID, string ip, string userID, DateTime date )
    {
        var tenMinThreshold = date - TimeSpan.FromMinutes(10);
        return this.context.FieldViewers.Where( x =>
            x.Field.FieldID == fieldID &&
            x.Viewer.IPAddress == ip &&
            x.Viewer.User.Id == userID &&
            x.Viewer.CreatedAt <= tenMinThreshold).FirstOrDefault();
    }
