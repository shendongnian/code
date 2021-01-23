    string conString = Microsoft
       .Extensions
       .Configuration
       .ConfigurationExtensions
       .GetConnectionString(this.Configuration, "DefaultConnection");
    
    System.Console.WriteLine(conString);
