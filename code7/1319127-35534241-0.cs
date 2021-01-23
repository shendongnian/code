     class Services
     {
         [Import]
         public ISettings Settings 
         { 
             get; set;
         }
         [Import]
         public ILogger Logger 
         {
            get;  set;
         }
     }
     static void Main()
     {
         AggregateCatalog catalog = new AggregateCatalog();
         catalog.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(SettingsProject.MySettings));
         catalog.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(LoggerProject.MyLogger));
         
         Services services = new Services();
 
         CompositionContainer cc = new CompositionContainer(catalog);
         cc.ComposeParts(services);
         
         // services properties are initialized           
           
     }
   
