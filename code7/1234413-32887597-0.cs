    public override async Task<bool> LoadAsync(string in_FileNameAndDirectory, StreamTask in_StreamTask, bool in_PreferRoaming)
    {
      if (PreferRoaming && SupportsRoamingSave)
      {
        try
        {
          return await RoamingLoadAsync(in_FileNameAndDirectory, in_StreamTask);
        }
        catch (Exception error)
        {
          return false;
        }
      }
      return Load(in_FileNameAndDirectory, in_StreamTask);
    }
