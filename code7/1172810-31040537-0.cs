    class Program
    {
        private static void Main()
        {
            DocumentTemplateProvider.SetDocTemplateProvider<Test>();
            //OR
            DocumentTemplateProvider.SetdocTemplateProvider(() => new Test());
            IDocumentTemplateProvider _template = DocumentTemplateProvider.TemplateProvider;
            
            Console.ReadLine();
        }
        public static class DocumentTemplateProvider
        {
            private static Func<IDocumentTemplateProvider> _docTemplateProvider;
            public static void SetdocTemplateProvider(Func<IDocumentTemplateProvider> docTemplateProvider)
            {
                _docTemplateProvider = docTemplateProvider;
            }
            public static void SetDocTemplateProvider<T>() where T : IDocumentTemplateProvider, new()
            {
                _docTemplateProvider = () => new T();
            }
            public static IDocumentTemplateProvider TemplateProvider
            {
                get { return _docTemplateProvider(); }
            }
        }
    }
    internal interface IDocumentTemplateProvider
    {
    }
    public class Test : IDocumentTemplateProvider
    {
    }
