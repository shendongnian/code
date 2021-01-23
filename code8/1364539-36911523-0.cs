public class MyDbContext : DbContext
{
  public MyDbContext : base("MyConnectionString")
  {
  }
}
That way I make sure it picks a specific connectionstring and I know I won't forget it, and what not.
