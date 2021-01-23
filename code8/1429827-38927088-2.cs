    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Runtime.InteropServices;
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidVSPackage1PkgString)]
    [ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids80.SolutionExists)]
    public sealed class VSPackage1Package : Package
    {
        public VSPackage1Package() { }
        EnvDTE.DTE dte;
        protected override void Initialize()
        {
            base.Initialize();
            dte = (EnvDTE.DTE)this.GetService(typeof(EnvDTE.DTE));
            dte.Events.SolutionEvents.Opened += SolutionEvents_Opened;
            dte.Events.SolutionEvents.AfterClosing += SolutionEvents_AfterClosing;
        }
        void SolutionEvents_AfterClosing() { MouseHook.Stop(); }
        void SolutionEvents_Opened()
        {
            MouseHook.Start();
            MouseHook.MouseAction += MouseHook_MouseAction;
        }
        void MouseHook_MouseAction(object sender, EventArgs e)
        {
            dte.ExecuteCommand("Build.BuildSolution");
        }
    }
