        public class SomeController
    {
        private DocumentDbRepository _documentDbRepositoy
        public SomeController(IDocumentDbRepository documentDbRepository)
        {
            _documentDbRepositoy = documentDbRepository
        }
    }
