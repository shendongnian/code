        public bool CheckForFieldViewByFieldIDIPAndUser( int fieldID, string ip, string userID )
    {
        return this.context.FieldViewers.FirstOrDefault( x => 
            x.Field.FieldID == fieldID &&
            x.Viewer.IPAddress == ip &&
            x.Viewer.User.Id == userID )!= null;
    }
