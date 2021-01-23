    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        static class TextBoxExtensions
        {
            private const uint EM_FMTLINES = 0x00C8;
            private const uint WM_GETTEXT = 0x000D;
            private const uint WM_GETTEXTLENGTH = 0x000E;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
            public static string[] GetWrappedLines(this TextBox textBox)
            {
                var handle = textBox.Handle;
                SendMessage(handle, EM_FMTLINES, 1, IntPtr.Zero);
                var size = SendMessage(handle, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero).ToInt32();
                if (size > 0)
                {
                    var builder = new StringBuilder(size + 1);
                    SendMessage(handle, WM_GETTEXT, builder.Capacity, builder);
                    return builder.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
                return new string[0];
            }
        }
    }
