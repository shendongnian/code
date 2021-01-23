    using Microsoft.WebPages.Compilation;
    public class PreApplicationStart
    {
       public static void InitializeApplication()
       {
           CodeGeneratorSettings.AddGlobalImport("QuickCodeLearning.Customers.Utilities");
       }
    }
