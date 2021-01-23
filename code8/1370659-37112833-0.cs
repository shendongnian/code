    if (drivemodified > localprops.DateModified)
    {
        using (var stream = await localread.OpenStreamForWriteAsync())
        {
            using (var contentStream = await _userDrive.Drive.Special.AppRoot.ItemWithPath(filepath).Content.Request().GetAsync())
            {
                contentStream.CopyTo(stream);
            }
        }
    }
