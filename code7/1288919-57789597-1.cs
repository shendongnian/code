    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }
        public DbSet<CustomObjectDto> CustomObjects { get; set; }
        public DbSet<ColorDto> Colors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed database with all Colors
            foreach (Color color in Enum.GetValues(typeof(Color)).Cast<Color>())
            {
                ColorDto colorDto = new ColorDto
                {
                    ID = color,
                    Name = color.ToString(),
                };
                modelBuilder.Entity<ColorDto>().HasData(colorDto);
            }
        }
    }
