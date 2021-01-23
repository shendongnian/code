    public partial class Publication: IPublication
    {
        public Person[] Author
        {
            get
            { return this.Author.Select(a => a.Name).ToArray(); }
               
        
        
            set
            {
                throw new NotImplementedException();
            }
        }
        public string[] AuthorReferenceID
        {
            get { return this.AuthorReference.Select(auth => auth.@ref).ToArray(); }
        }
    }
