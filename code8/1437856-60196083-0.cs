 c#
using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
namespace MyAppSample
{
    public class ClipboardMonitor : IDisposable
    {
        private readonly HwndSourceHook hook;
        private readonly HwndSource hwndSource;
        private IntPtr nextClipboardViewer;
        public ClipboardMonitor(HwndSource hwnd)
        {
            hwndSource = hwnd;
            hook = new HwndSourceHook(WndProc);
            hwndSource.AddHook(hook);
            nextClipboardViewer = NativeMethods.SetClipboardViewer(hwndSource.Handle);
        }
        public event EventHandler ClipboardChanged;
        protected virtual void OnClipboardChanged() => ClipboardChanged?.Invoke(this, EventArgs.Empty);
        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_DRAWCLIPBOARD:
                    OnClipboardChanged();
                    NativeMethods.SendMessage(nextClipboardViewer, msg, wParam, lParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (wParam == nextClipboardViewer) 
                        nextClipboardViewer = lParam;
                    else
                        NativeMethods.SendMessage(nextClipboardViewer, msg, wParam, lParam);
                    break;
            }
            return IntPtr.Zero;
        }
        #region Destructor
        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                NativeMethods.ChangeClipboardChain(hwndSource.Handle, nextClipboardViewer);
                hwndSource.RemoveHook(hook);
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ClipboardMonitor()
        {
            Dispose(false);
        }
        #endregion
    }
    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32.dll")]
        public static extern UIntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
Usage
// Call constructor from your Window class or using its HwndSource from anywhere e.g. ViewModel class
clipboardMonitor = new ClipboardMonitor((HwndSource)PresentationSource.FromVisual(this));
// Attach to event raising on WM_DRAWCLIPBOARD message is received
clipboardMonitor.ClipboardChanged += ClipboardMonitor_ClipboardChanged;
// Event handler
private void ClipboardMonitor_ClipboardChanged(object sender, EventArgs e)
{
    // Clipboard was changed, do your job here
}
// The class is IDisposable, call Dispose() on App closing
clipboardMonitor.Dispose();
