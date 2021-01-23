    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    using System.Windows.Interop;
    using Automated.ToolWindow;
    namespace Automated
    {
        public class MyElementHost : ElementHost
        {
            protected override void Dispose(bool disposing)
            {
                if (_contentControl != null)
                {
                    _contentControl.Loaded -= OnContentControlOnLoaded;
                    _contentControl = null;
                }
            
                base.Dispose(disposing);
            }
            private ContentControl _contentControl;
            // Hide the child element.
            public new UIElement Child 
            {
                get { return base.Child; }
                set
                {
                    _contentControl = new ContentControl();
                    _contentControl.Loaded += OnContentControlOnLoaded;
                    _contentControl.Content = value;
                    base.Child = _contentControl;
                }
            }
            private void OnContentControlOnLoaded(object sender, RoutedEventArgs e)
            {
                var s = PresentationSource.FromVisual(_contentControl) as HwndSource;
                s?.AddHook(ChildHwndSourceHook);
            }
            private const UInt32 DLGC_WANTARROWS = 0x0001;
            private const UInt32 DLGC_WANTTAB = 0x0002;
            private const UInt32 DLGC_WANTALLKEYS = 0x0004;
            private const UInt32 DLGC_HASSETSEL = 0x0008;
            private const UInt32 DLGC_WANTCHARS = 0x0080;
            private const UInt32 WM_GETDLGCODE = 0x0087;
            static IntPtr ChildHwndSourceHook(IntPtr hwnd, 
              int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                if (msg != WM_GETDLGCODE) return IntPtr.Zero;
                handled = true;
                return new IntPtr(DLGC_WANTCHARS | DLGC_WANTARROWS | DLGC_HASSETSEL);
            }
        }
    }
