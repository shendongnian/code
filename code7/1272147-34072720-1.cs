    //In your DbContext class
    using CodeFirstStoreFunctions;
    public class MyContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder builder) {
            builder.Conventions.Add(new FunctionsConvention("dbo", typeof(Udf));
        }
        //etc
    }
    //In a static class named Udf (in the same namespace as your context)
    using System.Data.Entity;
    public static class Udf {
        [DbFunction("CodeFirstDatabaseSchema", "ClrRound_10_4")]
        public static decimal ClrRound_10_4(decimal value) {
            throw new InvalidOperationException("Cannot call UDF directly!");
        }
    }
    //In your LINQ query
    from item in ctx.Items
    select new {
        ListPrice = Udf.ClrRound_10_4(item.Cost / (1M - item.Markup))
    };
