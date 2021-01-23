    class Path
    {
        public string Id { get; set; }
        public File File { get; set; }
    }
    
    class File
    {
        public Guid Id { get; set; }
        public ICollection<Version> Versions { get; set; }
    }
    
    class Version
    {
        public string Id { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "api";
            builder.EntityType<File>();
            var function = builder.EntityType<Path>().Function("getFileByName");
            function.Parameter<string>("name");
            //function.ReturnsFromEntitySet<File>("Files");
            function.ReturnsEntityViaEntitySetPath<File>("bindingParameter/File");
            function.IsComposable = true;
            builder.EntitySet<Path>("Paths");
            builder.EntitySet<Version>("Versions");
            var model = builder.GetEdmModel();
    
            string path = "Paths('1')/api.getFileByName(name='sd')/Versions('s')";
            var parser = new ODataUriParser(model, new Uri(path, UriKind.Relative));
            var pa = parser.ParsePath();
            Console.WriteLine(pa);
        }
    }
