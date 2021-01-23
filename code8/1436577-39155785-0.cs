    System.NotSupportedException was unhandled
      Message=The given path's format is not supported.
      Source=mscorlib
      StackTrace:
           at System.Security.Util.StringExpressionSet.CanonicalizePath(String path, Boolean needFullPath)
           at System.Security.Util.StringExpressionSet.CreateListFromExpressions(String[] str, Boolean needFullPath)
           at System.Security.Permissions.FileIOPermission.AddPathList(FileIOPermissionAccess access, AccessControlActions control, String[] pathListOrig, Boolean checkForDuplicates, Boolean needFullPath, Boolean copyPathList)
           at System.Security.Permissions.FileIOPermission..ctor(FileIOPermissionAccess access, AccessControlActions control, String[] pathList, Boolean checkForDuplicates, Boolean needFullPath)
           at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy)
           at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, String msgPath, Boolean bFromProxy)
           at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share)
           at System.IO.File.ReadAllBytes(String path)
           at WindowsFormsApplication1.Form1.button1_Click(Object sender, EventArgs e) in D:\Code\WindowsFormsApplication1\WindowsFormsApplication1\Form1.cs:line 25
           at System.Windows.Forms.Control.OnClick(EventArgs e)
           at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
           at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
           at System.Windows.Forms.Control.WndProc(Message& m)
           at System.Windows.Forms.ButtonBase.WndProc(Message& m)
           at System.Windows.Forms.Button.WndProc(Message& m)
           at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
           at System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
           at System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
           at System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(Int32 dwComponentID, Int32 reason, Int32 pvLoopData)
           at System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
           at System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
           at WindowsFormsApplication1.Program.Main() in D:\Code\WindowsFormsApplication1\WindowsFormsApplication1\Program.cs:line 17
           at System.AppDomain._nExecuteAssembly(Assembly assembly, String[] args)
           at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
           at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
           at System.Threading.ThreadHelper.ThreadStart()
      InnerException: 
