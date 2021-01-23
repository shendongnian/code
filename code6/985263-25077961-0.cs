    namespace ConsoleApplication1
    {
        class Program
        {
            public class Athlete
            {
                public int Id { get; set; }
                public string Name { get; set; }
    
                private ICollection<Workout> workouts;
                public virtual ICollection<Workout> Workouts
                {
                    get { return workouts ?? (workouts = new HashSet<Workout>()); }
                    set { workouts = value; }
                }
    
                private ICollection<TrainingPlan> trainingPlans;
                public virtual ICollection<TrainingPlan> TrainingPlans
                {
                    get { return trainingPlans ?? (trainingPlans = new HashSet<TrainingPlan>()); }
                    set { trainingPlans = value; }
                }
            }
    
            public class TrainingToPerform
            {
                public int Id { get; set; }
    
                public DateTime DateToPerform { get; set; }
    
                public virtual TrainingPlan TrainingPlan { get; set; }
                public virtual Workout Workout { get; set; }
            }
    
            public class Workout
            {
                public int Id { get; set; }
                public string Name { get; set; }
    
                public virtual Athlete Athlete { get; set; }
    
                private ICollection<TrainingToPerform> trainingsToPerform;
                public virtual ICollection<TrainingToPerform> TrainingsToPerform
                {
                    get { return trainingsToPerform ?? (trainingsToPerform = new HashSet<TrainingToPerform>()); }
                    set { trainingsToPerform = value; }
                }
            }
    
            public class TrainingPlan
            {
                public int Id { get; set; }
                public string Name { get; set; }
    
                public virtual Athlete Athlete { get; set; }
    
                private ICollection<TrainingToPerform> trainingsToPerform;
                public virtual ICollection<TrainingToPerform> TrainingsToPerform
                {
                    get { return trainingsToPerform ?? (trainingsToPerform = new HashSet<TrainingToPerform>()); }
                    set { trainingsToPerform = value; }
                }
            }
    
    
            public class Db3 : DbContext
            {
                public Db3()
                {
    
                }
    
                public DbSet<Athlete> Athletes { get; set; }
                public DbSet<Workout> Workouts { get; set; }
                public DbSet<TrainingPlan> TrainingPlans { get; set; }
                public DbSet<TrainingToPerform> TrainingsToPerform { get; set; }
    
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
    
                    modelBuilder.Entity<TrainingPlan>()
                        .HasKey(x => x.Id);
    
                    modelBuilder.Entity<Workout>()
                        .HasKey(x => x.Id);
    
                    modelBuilder.Entity<Athlete>()
                        .HasKey(x => x.Id);
    
                    modelBuilder.Entity<Athlete>()
                        .HasMany(a => a.TrainingPlans)
                        .WithRequired(t => t.Athlete)
                        .WillCascadeOnDelete(true)
                        ;
    
                    modelBuilder.Entity<Athlete>()
                        .HasMany(a => a.Workouts)
                        .WithRequired(t => t.Athlete)
                        .WillCascadeOnDelete(true)
                        ;
    
                    modelBuilder.Entity<TrainingToPerform>()
                        .HasKey(x => x.Id);
    
                    modelBuilder.Entity<TrainingToPerform>()
                        .HasRequired(t => t.Workout)
                        .WithOptional()
                        .WillCascadeOnDelete(false)
                        ;
    
                    modelBuilder.Entity<TrainingToPerform>()
                        .HasRequired(t => t.TrainingPlan)
                        .WithOptional()
                        .WillCascadeOnDelete(false)
                        ;         
                }
            }
    
            static void Main(string[] args)
            {
    
                var db = new Db3();
    
                var a = new Athlete { Name = "a6"};
                var w = new Workout { Name = "w6", Athlete = a };
                var t = new TrainingPlan { Name = "t6", Athlete = a };
                db.Athletes.Add(a);
                db.Workouts.Add(w);
                db.TrainingPlans.Add(t);
                db.SaveChanges();
    
                var wtp = new TrainingToPerform { TrainingPlan = t, Workout = w, DateToPerform = DateTime.Now };
    
                w.TrainingsToPerform.Add(wtp);
                t.TrainingsToPerform.Add(wtp);
    
    
                db.TrainingsToPerform.Add(wtp);
    
                db.SaveChanges();
    
                Console.WriteLine(db.TrainingsToPerform.First().Workout.Name);
    
            } 
        }
    }
