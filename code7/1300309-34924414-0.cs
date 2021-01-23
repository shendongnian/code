    object mapiObject; //on the class/global level
    ..
    mapiObject = Application.Session.MAPIOBJECT;
    ...
    Task.Factory.StartNew(() => {
      Redemption.RDOSession session = new Redemption.RDOSession();
      session.MAPIOBJECT = mapiObject;
      Redemption.RDOStore pstStore = session.Stores["YourStoreName"];
      Redemption.RDOFolder rootFolder = pstStore.IPMRootFolder;
      Redemption.RDOFolders folders = rootFolder.Folders;
      for (int i = 0; i < 500; i++)
      {
         var folder = folders.Add("Test" + DateTime.Now.Ticks);
         Marshal.ReleaseComObject(folder);
      }
      Marshal.ReleaseComObject(folders);
      Marshal.ReleaseComObject(rootFolder);
      Marshal.ReleaseComObject(session);
    }
