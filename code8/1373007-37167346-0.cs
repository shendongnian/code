    [HttpGet("test/{id}/answers")]
    public IEnumerable<Answer> GetAnswersByTestId(int id){}     
    
    [HttpGet("test/{id}")]
    public IEnumerable<Test> GeTestById(int id) {}
