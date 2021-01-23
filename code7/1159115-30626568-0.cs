    public class User { public Guid UserId { get; set; } }
    public class Document
    {
        public string Name { get; private set; }
        private ICollection<User> sharedWith = new List<User>();
        private DateTime? publishedOn;
        public Document(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required");
            }
            this.Name = name;
        }
        public void Publish()
        {
            if (this.publishedOn.HasValue == false)
            {
                this.publishedOn = DateTime.UtcNow;
            }
        }
        public void SharedWith(User user)
        {
            if (this.publishedOn.HasValue == false)
            {
                throw new InvalidOperationException("Document must be published for sharing is allowed.");
            }
            sharedWith.Add(user);
        }
    }
    public interface IDocumentRepository
    {
        Document documentOfId(Guid id);
        bool IsAlreadySharedWith(Guid documentId, Guid userId);
    }
    public interface IUseRepository
    {
        User userOfId(Guid id);
    }
    public class ShareDocumentService
    {
        private readonly IUseRepository userRepository;
        private readonly IDocumentRepository documentRepository;
        public void ShareWith(Guid userId, Guid documentId)
        {
            if (documentRepository.IsAlreadySharedWith(documentId, userId))
                throw new InvalidOperationException("Document has already been shared with user.");
            User user = userRepository.userOfId(userId);
            Document doc = documentRepository.documentOfId(documentId);
            doc.SharedWith(user);
        }
    }
