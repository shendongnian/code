    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private readonly CoreDBContext context = new CoreDBContext();
        /// <summary>
        /// StudentRepository repository.
        /// </summary>
        public StudentRepository studentRepository 
        {
            get { return this.studentRepository ?? (this.studentRepository = new studentRepository (this.context)); }
        }
        
        public OtherRepository otherRepository
        {
            get { return this.otherRepository?? (this.otherRepository= new otherRepository(this.context)); }
        }
        /// <summary>
        /// Saves changes to database.
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
