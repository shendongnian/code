    [STAThread]
    static void Main()
    {
     AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(ReturnXtraForm());
    }
    private static Assembly CurrentDomainOnAssemblyResolve(object sender,   ResolveEventArgs args)
    {
    // the ddls are in a lib folder.
     String resourceName = "MyApplication." + "lib." + new AssemblyName(args.Name).Name + ".dll";
     using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
     {
        if (stream != null)
        {
           Byte[] assemblyData = new Byte[stream.Length];
           stream.Read(assemblyData, 0, assemblyData.Length);
           return Assembly.Load(assemblyData);
        }
     }
     return null;
    }
    private static Form ReturnXtraForm() {
          DevExpress.Skins.SkinManager.EnableFormSkins();
          UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
          return new MyForm();
      }
