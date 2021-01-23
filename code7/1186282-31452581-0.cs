    class Client
    {                
        public int Id { get; set; }
                                     
        public Client Parent { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// 
        /// WITH PARENT
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="parent">The parent.</param>
        public Client(int id, Client parent)
        {
            this.Id = id;
            this.Parent = parent;                    
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// 
        /// WITHOUT PARENT
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Client(int id)
        {
            this.Id = id;
        }
    }
    public static void Main(string[] args)
    {
            Client client = new Client(1);
            Client clientWithParent = new Client(2, client);
            Console.Write("parent id :" + clientWithParent.Parent.Id);
    }
