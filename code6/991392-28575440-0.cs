        public class MultiAssemblyMigrationLoader : IMigrationInformationLoader
    {
        public MultiAssemblyMigrationLoader(IMigrationConventions conventions, IEnumerable<Assembly> assemblies, string @namespace, IEnumerable<string> tagsToMatch)
            : this(conventions, assemblies, @namespace, false, tagsToMatch)
        {
        }
        public MultiAssemblyMigrationLoader(IMigrationConventions conventions, IEnumerable<Assembly> assemblies, string @namespace, bool loadNestedNamespaces, IEnumerable<string> tagsToMatch)
        {
            this.Conventions = conventions;
            this.Assemblies = assemblies;
            this.Namespace = @namespace;
            this.LoadNestedNamespaces = loadNestedNamespaces;
            this.TagsToMatch = tagsToMatch ?? new string[0];
        }
        public IMigrationConventions Conventions { get; private set; }
        public IEnumerable<Assembly> Assemblies { get; private set; }
        public string Namespace { get; private set; }
        public bool LoadNestedNamespaces { get; private set; }
        public IEnumerable<string> TagsToMatch { get; private set; }
        public SortedList<long, IMigrationInfo> LoadMigrations()
        {
            var sortedList = new SortedList<long, IMigrationInfo>();
            IEnumerable<IMigration> migrations = this.FindMigrations();
            if (migrations == null) return sortedList;
            foreach (IMigration migration in migrations)
            {
                IMigrationInfo migrationInfo = this.Conventions.GetMigrationInfo(migration);
                if (sortedList.ContainsKey(migrationInfo.Version))
                    throw new DuplicateMigrationException(string.Format("Duplicate migration version {0}.", migrationInfo.Version));
                sortedList.Add(migrationInfo.Version, migrationInfo);
            }
            return sortedList;
        }
        private IEnumerable<IMigration> FindMigrations()
        {
            IEnumerable<Type> types = new Type[] { };
            foreach (var assembly in Assemblies)
            {
                types = types.Concat(assembly.GetExportedTypes());
            }
            IEnumerable<Type> source = types.Where(t =>
                                                        {
                                                            if (!Conventions.TypeIsMigration(t))
                                                                return false;
                                                            if (!Conventions.TypeHasMatchingTags(t, this.TagsToMatch))
                                                                return !Conventions.TypeHasTags(t);
                                                            return true;
                                                        });
            if (!string.IsNullOrEmpty(Namespace))
            {
                Func<Type, bool> predicate = t => t.Namespace == Namespace;
                if (LoadNestedNamespaces)
                {
                    string matchNested = Namespace + ".";
                    predicate = t =>
                                    {
                                        if (t.Namespace != Namespace)
                                            return t.Namespace.StartsWith(matchNested);
                                        return true;
                                    };
                }
                source = source.Where(predicate);
            }
            return source.Select(matchedType => (IMigration)matchedType.Assembly.CreateInstance(matchedType.FullName));
        }
    }
