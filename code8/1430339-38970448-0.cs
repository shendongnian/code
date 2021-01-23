    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    
    namespace Company.MyVSPackage
    {
       // Only load the package if there is a solution loaded
       [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string)]
       [PackageRegistration(UseManagedResourcesOnly = true)]
       [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
       [Guid(GuidList.guidMyVSPackagePkgString)]
       public sealed class MyVSPackagePackage : Package
       {
          public MyVSPackagePackage()
          {
          }
    
          protected override void Initialize()
          {
             base.Initialize();
    
             ShowSolutionProperties();
          }
    
          private void ShowSolutionProperties()
          {
             SVsSolution solutionService;
             IVsSolution solutionInterface;
             bool isSolutionOpen;
             string solutionDirectory;
             string solutionFullFileName;
             int projectCount;
    
             // Get the Solution service
             solutionService = (SVsSolution)this.GetService(typeof(SVsSolution));
    
             // Get the Solution interface of the Solution service
             solutionInterface = solutionService as IVsSolution;
    
             // Get some properties
    
             isSolutionOpen = GetPropertyValue<bool>(solutionInterface, __VSPROPID.VSPROPID_IsSolutionOpen);
             MessageBox.Show("Is Solution Open: " + isSolutionOpen);
    
             if (isSolutionOpen)
             {
                solutionDirectory = GetPropertyValue<string>(solutionInterface, __VSPROPID.VSPROPID_SolutionDirectory);
                MessageBox.Show("Solution directory: " + solutionDirectory);
    
                solutionFullFileName = GetPropertyValue<string>(solutionInterface, __VSPROPID.VSPROPID_SolutionFileName);
                MessageBox.Show("Solution full file name: " + solutionFullFileName);
    
                projectCount = GetPropertyValue<int>(solutionInterface, __VSPROPID.VSPROPID_ProjectCount);
                MessageBox.Show("Project count: " + projectCount.ToString());
             }
          }
    
          private T GetPropertyValue<T>(IVsSolution solutionInterface, __VSPROPID solutionProperty)
          {
             object value = null;
             T result = default(T);
    
             if (solutionInterface.GetProperty((int)solutionProperty, out value) == Microsoft.VisualStudio.VSConstants.S_OK)
             {
                result = (T)value;
             }
             return result;
          }
       }
    }
