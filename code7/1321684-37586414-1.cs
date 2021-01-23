    public class PersonModel
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime? BirthDate {get; set;}
        public HttpFile AvatarImage {get; set;}
        public List<HttpFile> Attachments {get; set;}
        public List<PersonModel> ConnectedPersons {get; set;}
    }
    //api controller example
    [HttpPost]
    public void PostPerson(PersonModel model)
    {
        //do something with the model
    }
