    public class MyContext : DbContext
    {
        public DbSet<Values> Values { get; set; }
        public DbSet<GQMetric> GqMetric { get; set; }
        public DbSet<ValuesMetrics> ValuesMetrics { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Values>().HasKey(values => values.Values_ID);
            modelBuilder.Entity<GQMetric>().HasKey(metric => metric.GQMetric_ID);
            modelBuilder
                .Entity<ValuesMetrics>()
                .HasKey(valuesMetrics => new
                {
                    valuesMetrics.Value_ID,
                    valuesMetrics.GQMetric_ID
                });
            modelBuilder
                .Entity<ValuesMetrics>()
                .HasRequired(valuesMetrics => valuesMetrics.Values)
                .WithMany(valueMetrics => valueMetrics.ValuesMetrics)
                .HasForeignKey(valueMetrics => valueMetrics.Value_ID);
            modelBuilder
                .Entity<ValuesMetrics>()
                .HasRequired(valuesMetrics => valuesMetrics.GQMetric)
                .WithMany(valueMetrics => valueMetrics.ValuesMetrics)
                .HasForeignKey(valueMetrics => valueMetrics.GQMetric_ID);
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Values
    {
        public int Values_ID { get; set; }
        public string Values_Name { get; set; }
        public int ValuesNumeric { get; set; }
        public virtual ICollection<ValuesMetrics> ValuesMetrics { get; set; }
    }
    public class GQMetric
    {
        public int GQMetric_ID { get; set; }
        public string GQMetricName { get; set; }
        public virtual ICollection<ValuesMetrics> ValuesMetrics { get; set; }
    }
    public class ValuesMetrics
    {
        public int GQMetric_ID { get; set; }
        public int Value_ID { get; set; }
        public virtual GQMetric GQMetric { get; set; }
        public virtual Values Values { get; set; }
    }
