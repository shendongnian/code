    public class TypeManager
    {
        public void Compose()
        {
            try
            {
                var directoryPath = Path.GetFullPath(".");
                var aggregateCatalog = new AggregateCatalog();
                aggregateCatalog.Catalogs.Add(new DirectoryCatalog(directoryPath, "*.dll"));
                //Create the composition container
                var container = new CompositionContainer(aggregateCatalog);
                container.ComposeParts(this);
                var cat = container.GetExportedValue<Cat>();
                cat.Name = "lucy";
                var dog = container.GetExportedValue<AnimalAggressiveBase<Cat>>();
                var manager = new AnimalManager();
                manager.WatchAnimal(dog, cat);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
                throw;
            }
        }
    }
