    public class Document : IAcceptDocumentVisitor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public string FileData { get; private set; }
        public Document(int id, string name, string filePath, string fileData)
        {
            Id = id;
            Name = name;
            FilePath = filePath;
            FileData = fileData;
        }
        /// <summary>
        /// This method replace SubmitForProcessing
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IDocumentVisitor visitor)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            visitor.Visit(Name, FileData);
        }
        public void ReplaceFileData(string fileData, Action onSuccess)
        {
            //Business valdation 
            var validate = true;
            //Business valdation 
            if (!validate) return;
            FileData = fileData;
            onSuccess();
        }
    }
    public interface IAcceptDocumentVisitor
    {
        void Accept(IDocumentVisitor visitor);
    }
    public interface IDocumentVisitor
    {
        void Visit(string name, string fileData);
    }
    public class FakeWebServiceVisitor : IDocumentVisitor
    {
        public void Visit(string name, string fileData)
        {
            Name = name;
            FileData = fileData;
        }
        public string FileData { get; set; }
        public string Name { get; set; }
    }
    public class WebServiceVisitor : IDocumentVisitor
    {
        public void Visit(string name, string fileData)
        {
            //Call web service
            //webService.ExecuteFoo(this.Name, this.FileData);
        }
    }
    public interface IDocumentReader
    {
        Document GetById(int id);
    }
    public class DocumentDbReader : IDocumentReader
    {
        public Document GetById(int id)
        {
            //Get from database
            //Document newDoc = db.Query<Document>("SELECT Name, FilePath FROM Documents WHERE ID = @pID", new { pID = documentID });
            return new Document(id, "Name", "Path", "Data");
        }
    }
