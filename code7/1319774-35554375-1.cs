    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Threading;
    using System.Windows.Forms;
    class CustomSynchronizationContext : SynchronizationContext
    {
    	public static void Install()
    	{
    		var currentContext = Current;
    		if (currentContext is CustomSynchronizationContext) return;
    		WindowsFormsSynchronizationContext.AutoInstall = false;
    		SetSynchronizationContext(new CustomSynchronizationContext(currentContext));
    	}
    
    	public static void Uninstall()
    	{
    		var currentContext = Current as CustomSynchronizationContext;
    		if (currentContext == null) return;
    		SetSynchronizationContext(currentContext.baseContext);
    	}
    
    	private WindowsFormsSynchronizationContext baseContext;
    
    	private CustomSynchronizationContext(SynchronizationContext currentContext)
    	{
    		baseContext = currentContext as WindowsFormsSynchronizationContext  ?? new WindowsFormsSynchronizationContext();
    		SetWaitNotificationRequired();
    	}
    
    	public override SynchronizationContext CreateCopy() { return this; }
    	public override void Post(SendOrPostCallback d, object state) { baseContext.Post(d, state); }
    	public override void Send(SendOrPostCallback d, object state) { baseContext.Send(d, state); }
    	public override void OperationStarted() { baseContext.OperationStarted(); }
    	public override void OperationCompleted() { baseContext.OperationCompleted(); }
    
    	public override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
    	{
    		int result = WaitForMultipleObjectsEx(waitHandles.Length, waitHandles, waitAll, millisecondsTimeout, false);
    		if (result == -1) throw new Win32Exception();
    		return result;
    	}
    
    	[SuppressUnmanagedCodeSecurity]
    	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    	private static extern int WaitForMultipleObjectsEx(int nCount, IntPtr[] pHandles, bool bWaitAll, int dwMilliseconds, bool bAlertable);
    }
