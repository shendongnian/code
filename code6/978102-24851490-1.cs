    public void EditAlbum (Album newAlbum)
    {
        command.CommandText = @"UPDATE Album SET [Name]=@Name, 
                                [Description]=@Description, 
                                [Location]=@Location, 
                                [Date]=@Date,
                                [CoverPhotoURL]=@Cover 
                                WHERE [ID]=@Id";
        command.Parameters.AddWithValue("@Name", newAlbum.Name);
        command.Parameters.AddWithValue("@Description", newAlbum.Description);
        command.Parameters.AddWithValue("@Location", newAlbum.Location);
        command.Parameters.AddWithValue("@Data", newAlbum.Date);
        command.Parameters.AddWithValue("@Cover", newAlbum.CoverPhoto);
        // Moved after the Cover parameter
        command.Parameters.AddWithValue("@Id", newAlbum.ID);
        command.ExecuteNonQuery();
    }
