     public class Programm
        {
            public static void Main()
            {
                 List<ChangesSummary>  summaries = new List<ChangesSummary>();
    
                 summaries.Add(new ChangesSummary()
                 {
                     FieldName = "1",
                     ProviderKey = "Test1",
                 });
    
                 summaries.Add(new ChangesSummary()
                 {
                     FieldName = "2",
                     ProviderKey = "Test2",
                 });
    
                 summaries.Add(new ChangesSummary()
                 {
                     FieldName = "3",
                     ProviderKey = "Test3",
                 });
    
                List<string> listProviderKeys = new List<string>();
    
                listProviderKeys.Add("Test1");
                listProviderKeys.Add("Test3");
    
                var res = summaries.Where(x => !listProviderKeys.Contains(x.ProviderKey));
    
    
                res.ToList().ForEach(x => Console.WriteLine(x.ProviderKey));
    
                Console.ReadLine();
            }
        }
    
        public class ChangesSummary
        {
            public string TableName { get; set; }
            public string ProviderKey { get; set; }
            public string ProviderAdrsKey { get; set; }
            public string ProviderSpecialtyKey { get; set; }
            public string FieldName { get; set; }
        }
