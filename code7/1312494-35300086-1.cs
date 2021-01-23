     XmlSerializer xmlSr = new XmlSerializer(typeof(List<ProjectObject>));
     using(FileStream reader = new FileStream(mTextFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
     {
         try
         {
             List<ProjectObject> addProjects = (List<ProjectObject>)xmlSr.Deserialize(reader);
             mSharedDriveLocalProjects = addProjects;
         }
         catch
         {
             MessageBox.Show("Failed to load XML file");
         }
    }
