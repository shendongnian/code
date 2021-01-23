    public class RecipeContext : DbContext
    { 
         // the default constructor
         public RecipeContext()  : base() { }
         // this one lets you pass a connection string
         public RecipeContext( string connectionString ) : base( connectionString ) { }
         ...
