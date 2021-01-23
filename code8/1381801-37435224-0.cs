    static void Main(string[] args)
    {
      using (DevartContext ctx = new DevartContext())
      {
        // prevent model-changes from wrecking the test
        ctx.Database.Delete();
        ctx.Database.Create();
        ctx.Bases.Add(new SubA());
        ctx.Bases.Add(new SubAA());
        ctx.Bases.Add(new SubB());
    
        ctx.SaveChanges();
    
        var result = ctx.Bases.Where(x => x.TypeId == 1);
        // throws on materialization, why?
        foreach (var entry in result)
        {
          Console.WriteLine(entry);
        }
      }
       Console.ReadLine();
      }
    
    
    public abstract class Base
    {
      public int Id { get; set; }
    
      public virtual int TypeId { get; set; } 
    }
    public class SubA : Base
    {
      public override int TypeId { get; set; } = 1;
    }
    public class SubAA : SubA
    {
      public override int TypeId { get; set; } = 2;
    }
    public class SubB : Base
    {
      public override int TypeId { get; set; } = 3;
    }
    public class SubC : Base
    {
      public override int TypeId { get; set; } = 4;
    }
    
    public class DevartContext : DbContext
    {
      public DbSet<Base> Bases { get; set; }
    
      public DevartContext()
      {
      }
    }
