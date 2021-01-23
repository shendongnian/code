    static void Main(string[] args) {                        
        System.IO.Directory.SetCurrentDirectory(@"G:\Python27\Lib");
        var engine = Python.CreateEngine();            
        dynamic io = engine.ImportModule("io");            
        var  f = (PythonIOModule._IOBase) io.open("tmp.txt", "w");
        var languageContext = HostingHelpers.GetLanguageContext(engine);
        var context = new ModuleContext(io._io, new PythonContext(languageContext.DomainManager, new Dictionary<string, object>())).GlobalContext;            
        f.writelines(context, "some text....");
        f.close(context);
    }
