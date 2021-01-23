    [TestMethod]
    public void Test_Method_Delete()
    {
        Tag tag = new Tag()
        {
            Id = Guid.Parse(""), // Inside the quotes use a valid Id from your database.
            Name = "Test tag5"
        }; 
        Tag tag1 = new Tag()
        {
            Name = "Test tag3"
        }; 
        Tag tag2 = new Tag()
        {
            Name = "Test tag4"
        };
        _tagRepo.Delete(GetById(tag.Id));
    }
