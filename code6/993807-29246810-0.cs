    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class MovieReviewService
    {
        private MovieContext movieContex;
        private ReviewContext reviewContext;
        private CommentContext commentContext;
        public MovieReviewService(string connectionString)
        {
            this.movieContex = new MovieContext(connectionString);
            this.reviewContext = new ReviewContext(connectionString);
            this.commentContext = new CommentContext(connectionString);
        }
        public void AddMovie(Movie movie)
        {
            this.movieContex.Add(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            this.movieContex.Update(movie);
        }
        public void DeleteMovie(int id)
        {
            this.movieContex.Delete(id);
        }
        public Movie GetMovie(int id)
        {
            return this.movieContex.Get(id);
        }
    }
    internal class MovieContext : DbContext
    {
        private DbSet<Movie> Movies { get { return this.Set<Movie>(); } }
        internal MovieContext(string connectionString)
            : base(connectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Movie>()
                .HasKey(key => key.Id);
            base.OnModelCreating(modelBuilder);
        }
        internal void Add(Movie movie)
        {
            var existing = this.Movies.Find(movie.Id);
            if (existing == null)
            {
                existing.Id++;
                existing.Title = movie.Title;
                this.Entry<Movie>(existing).State = EntityState.Added;
                this.SaveChanges();
            }
        }
        internal void Update(Movie movie)
        {
            var existing = this.Movies.Find(movie.Id);
            if (existing != null)
            {
                existing.Title = movie.Title;
                this.Entry<Movie>(existing).State = EntityState.Modified;
                this.SaveChanges();
            }
        }
        internal void Delete(int movieId)
        {
            var movie = this.Movies.Find(movieId);
            if (movie != null)
            {
                this.Entry<Movie>(movie).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }
        internal Movie Get(int movieId)
        {
            return this.Movies.Find(movieId);
        }
        internal IEnumerable<Movie> GetAll()
        {
            return this.Movies;
        }
    }
    internal class ReviewContext : DbContext
    {
        private DbSet<Review> Movies { get { return this.Set<Review>(); } }
        internal ReviewContext(string connectionString)
            : base(connectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Review>()
                .HasKey(key => key.Id)
                .HasMany(comment => comment.Comments);
            base.OnModelCreating(modelBuilder);
        }
        //add your features or action
    }
    internal class CommentContext : DbContext
    {
        private DbSet<Comment> Movies { get { return this.Set<Comment>(); } }
        internal CommentContext(string connectionString)
            : base(connectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Comment>()
                .HasKey(key => key.Id);
            base.OnModelCreating(modelBuilder);
        }
        //add your features or action
    }
