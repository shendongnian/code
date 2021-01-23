        public class DocumentDto
        {
            public Guid Id { get; set; }
            public DocumentType DocumentType { get; set; }
            public string DocumentNumber { get; set; }
            public DateTime DocumentDate { get; set; }
        }
    
        [Route("api/document/GetItem/{id}")]
        [HttpGet]
        public DocumentDto GetItem(string Id)
        {
            var doc = service.GetItem(Id).Value;
            return new DocumentDto(){
                Id = doc.Id,
                //set other properties from doc
            };
        }
