    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.ComponentModel.Design;
    using Microsoft.Win32;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using EnvDTE;
    
    namespace Dinto.NoCopy
    {
        [PackageRegistration(UseManagedResourcesOnly = true)]
        [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
        [Guid(GuidList.guidNoCopyPkgString)]
        [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
        public sealed class NoCopyPackage : Package
        {
            public NoCopyPackage()
            {
                Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
            }
    
            #region Package Members
    
    
            private EnvDTE.DTE m_objDTE = null;
            private CommandEvents _pasteEvent;
    
            protected override void Initialize()
            {
                Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
                base.Initialize();
    
                m_objDTE = (DTE)GetService(typeof(DTE));
    
                var pasteGuid = typeof(VSConstants.VSStd97CmdID).GUID.ToString("B");
                var pasteID = (int)VSConstants.VSStd97CmdID.Copy;
    
                _pasteEvent = m_objDTE.Events.CommandEvents[pasteGuid, pasteID];
                _pasteEvent.BeforeExecute += CopyRead;
    
            }
            #endregion
    
            private void CopyRead (
              string Guid,
              int ID,
              Object CustomIn,
              Object CustomOut,
              ref bool CancelDefault
              )
            {
              EnvDTE.Command objCommand;
              string commandName = "";
    
    
              objCommand = m_objDTE.Commands.Item(Guid, ID);
              if (objCommand != null)
              {
                commandName = objCommand.Name;
              }
    
              if (commandName.Equals("Edit.Copy"))
              {
                TextSelection textSelection = (TextSelection)m_objDTE.ActiveDocument.Selection;
    
                if (textSelection.IsEmpty)
                {
                  CancelDefault = true;
                }
              }
            }
    
        }
    }
