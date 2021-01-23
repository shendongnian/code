    public interface IBasket
    {
        IDictionary<int, IApple> GetAppleDictionary();
    }
    [Export(typeof(IBasket))]
    public class Basket : IBasket
    {
        private IDictionary<int, IApple> dict;
        [ImportingConstructor]
        public Basket([Import] CompositionContainer container)
        {
            this.dict = new Dictionary<int, IApple>();
            for (int i = 0; i < 10; i++)
            {
                this.dict.Add(i, container.GetExportedValue<IApple>());
            }
        }
        public IDictionary<int, IApple> GetAppleDictionary()
        {
            return dict;
        }
    }
    class Program
    {
        [Import(typeof(IBasket))]
        private IBasket basket = null;
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
        private void Run()
        {
            var catalog = new ApplicationCatalog();
            var container = CreateCompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var pair in this.basket.GetAppleDictionary())
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
        private static CompositionContainer CreateCompositionContainer(ComposablePartCatalog catalog)
        {
            var wrappedCatalog = new AggregateCatalog(catalog, new TypeCatalog(typeof (CompositionContainer)));
            var result = new CompositionContainer(wrappedCatalog);
            result.ComposeExportedValue(result);
            return result;
        }
    }
