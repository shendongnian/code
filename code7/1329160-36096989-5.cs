    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidVSPackage1PkgString)]
    [ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids80.SolutionExists)]
    public sealed class VSPackage1Package : Package
    {
        public VSPackage1Package() { }
        protected override void Initialize()
        {
            base.Initialize();
            TypeDescriptor.AddAttributes(typeof(Color), new EditorAttribute(typeof(CustomColorEditor), typeof(UITypeEditor)));
        }
    }
