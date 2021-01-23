    public class ProjectDataAccess : IProjectDataAccess
    {
        public Models.ProjectModel Get(string filePath)
        {
            Models.ProjectModel project = new Models.ProjectModel();
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.ProjectModel));
            // To read the file, create a FileStream.
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            project = (Models.ProjectModel)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            return project;
        }
        public void Save(Models.ProjectModel project, string filePath)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(project.GetType());
            StreamWriter streamWriter = new StreamWriter(filePath);
            xmlSerializer.Serialize(streamWriter, project);
            streamWriter.Close();
        }
    }
