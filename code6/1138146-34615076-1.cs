    public class TableControllerSelector : DefaultHttpControllerSelector
    {
        private Dictionary<string, HttpControllerDescriptor> _tables = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
        public TableControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }
        public HttpConfiguration Configuration { get; private set; }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            string name = GetControllerName(request);
            if (name != null) // is it a known table name?
            {
                HttpControllerDescriptor desc;
                if (_tables.TryGetValue(name, out desc))
                    return desc;
            }
            return base.SelectController(request);
        }
        public void AddTable(string connectionString, DatabaseTable table)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");
            if (table == null)
                throw new ArgumentNullException("table");
            // create a descriptor with extra properties that the controller needs
            var desc = new HttpControllerDescriptor(Configuration, table.Name, typeof(TableController));
            desc.Properties["table"] = table;
            desc.Properties["connectionString"] = connectionString;
            _tables[table.Name] = desc;
        }
    }
    public class TableController : ODataController
    {
        // this will be called for standard OData access to collection
        public EdmEntityObjectCollection Get()
        {
            // get Edm type from request
            ODataPath path = Request.ODataProperties().Path; // ODataProperties() needs using System.Web.OData.Extensions
            IEdmType edmType = path.EdmType;
            IEdmCollectionType collectionType = (IEdmCollectionType)edmType;
            IEdmEntityType entityType = (IEdmEntityType)collectionType.ElementType.Definition;
            IEdmModel model = Request.ODataProperties().Model;
            ODataQueryContext queryContext = new ODataQueryContext(model, entityType, path);
            ODataQueryOptions queryOptions = new ODataQueryOptions(queryContext, Request);
            // TODO: apply the query option on the IQueryable here.
            // read all rows from table (could be optimized using query context)
            var table = (DatabaseTable)ControllerContext.ControllerDescriptor.Properties["table"];
            var cnx = (string)ControllerContext.ControllerDescriptor.Properties["connectionString"];
            return new EdmEntityObjectCollection(new EdmCollectionTypeReference(collectionType), ReadData(entityType, table, cnx));
        }
        public static IList<IEdmEntityObject> ReadData(IEdmEntityType type, DatabaseTable table, string connectionString)
        {
            List<IEdmEntityObject> list = new List<IEdmEntityObject>();
            // https://www.nuget.org/packages/DatabaseSchemaReader/
            Reader reader = new Reader(table, connectionString, "System.Data.SqlClient");
            reader.Read((r) =>
            {
                EdmEntityObject obj = new EdmEntityObject(type);
                foreach (var prop in type.DeclaredProperties)
                {
                    int index = r.GetOrdinal(prop.Name);
                    object value = r.GetValue(index);
                    if (Convert.IsDBNull(value))
                    {
                        value = null;
                    }
                    obj.TrySetPropertyValue(prop.Name, value);
                }
                list.Add(obj);
                // uncomment these 2 lines if you're just testing maximum 10 rows on a table 
                //if (list.Count == 10)
                //    return false;
                return true;
            });
            return list;
        }
        public static IEdmModel GetEdmModel(string connectionString, TableControllerSelector selector)
        {
            EdmModel model = new EdmModel();
            // create and add entity container
            EdmEntityContainer container = new EdmEntityContainer("NS", "DefaultContainer");
            model.AddElement(container);
            // https://www.nuget.org/packages/DatabaseSchemaReader/
            using (var dbReader = new DatabaseReader(connectionString, "System.Data.SqlClient"))
            {
                var schema = dbReader.ReadAll();
                foreach (var table in schema.Tables)
                {
                    EdmEntityType tableType = new EdmEntityType("NS", table.Name);
                    foreach (var col in table.Columns)
                    {
                        var kind = GetKind(col);
                        if (!kind.HasValue) // don't map this
                            continue;
                        var prop = tableType.AddStructuralProperty(col.Name, kind.Value, col.Nullable);
                        if (col.IsPrimaryKey)
                        {
                            tableType.AddKeys(prop);
                        }
                    }
                    model.AddElement(tableType);
                    EdmEntitySet products = container.AddEntitySet(table.Name, tableType);
                    selector.AddTable(connectionString, table);
                }
            }
            return model;
        }
        // determine Edm kind from column type
        private static EdmPrimitiveTypeKind? GetKind(DatabaseColumn col)
        {
            var dt = col.DataType;
            if (col.DataType == null)
                return null;
            Type type = col.DataType.GetNetType();
            if (type == null)
                return null;
            if (type == typeof(string))
                return EdmPrimitiveTypeKind.String;
            if (type == typeof(short))
                return EdmPrimitiveTypeKind.Int16;
            if (type == typeof(int))
                return EdmPrimitiveTypeKind.Int32;
            if (type == typeof(long))
                return EdmPrimitiveTypeKind.Int64;
            if (type == typeof(bool))
                return EdmPrimitiveTypeKind.Boolean;
            if (type == typeof(Guid))
                return EdmPrimitiveTypeKind.Guid;
            if (type == typeof(DateTime))
                return EdmPrimitiveTypeKind.DateTimeOffset;
            if (type == typeof(TimeSpan))
                return EdmPrimitiveTypeKind.Duration;
            if (type == typeof(decimal))
                return EdmPrimitiveTypeKind.Decimal;
            if (type == typeof(byte) || type == typeof(sbyte))
                return EdmPrimitiveTypeKind.Byte;
            if (type == typeof(byte[]))
                return EdmPrimitiveTypeKind.Binary;
            if (type == typeof(double))
                return EdmPrimitiveTypeKind.Double;
            if (type == typeof(float))
                return EdmPrimitiveTypeKind.Single;
            return null;
        }
    }
