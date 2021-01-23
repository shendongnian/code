    public class DbSheets : BehaviorClass<DbSheets, Sheet>
    {
      public override void Create(List<Sheet> sheets, out string message){...}
      public override void Delete(List<Sheet> sheets, out string message){...}
      ...
    }
    
    internal class Program
    {
      ...
      DbSheets.Import();
      ...
    }
