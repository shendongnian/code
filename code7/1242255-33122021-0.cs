    public class ModelClass : BaseModel, IUser
    {
        public string Name { get; set; }
        string IUset<string>Id { get { return this.Id.ToString(); } }
    }
