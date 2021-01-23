    foreach (OLEObject obj in _WorkSheetExcel.OLEObjects())
    {
          Hashtable hs = new Hashtable();
          DirectoryInfo direct = new DirectoryInfo(tempdir);
          foreach (FileInfo file in direct.GetFiles())
          {
              hs.Add(file.Name, null);//get all file names in tempdir
          }
          obj.Activate();//activate oleobject
          foreach (FileInfo file in direct.GetFiles())
          {
              if (!hs.ContainsKey(file.Name) && !file.Extension.ToLower().Contains("tmp"))//find new activated file 
              {
                   FileInfo picture = file.CopyTo(pathpicture + picturename  + file.Extension); //copy picture to folder with original extension
                   break;
              }
          }
    }
