    public class CrmObject
    {
        [ImportParameter]
        public string Name { get; set; }
    }
    public class Aufgabe : CrmObject
    {
        [ImportParameter]
        public int Id { get; set; }
    }
    public class ImportParameterAttribute : Attribute
    {
        
    }
    public class InheritenceProgram
    {
        public static void Main()
        {
            var propertyInfos = typeof(CrmObject).Assembly.GetType("Aufgabe").GetProperties().Where(p => Attribute.IsDefined(p, typeof(ImportParameterAttribute)));
            var list = propertyInfos.ToList();
        }
    }
