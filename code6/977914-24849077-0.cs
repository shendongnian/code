    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class RichTextBoxX : RichTextBox
    {
        //// see http://social.msdn.microsoft.com/Forums/vstudio/en-US/ba339154-95b7-4e13-a2c0-32593cadb984/richtextbox-vscrollbar?forum=vbgeneral
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private uint WM_VSCROLL = 0x115;
        private const uint SB_LINEUP = 0;
        private const uint SB_LINEDOWN = 1;
        private const uint SB_PAGEUP = 2;
        private const uint SB_PAGEDOWN = 3;
        private const uint SB_TOP = 6;
        private const uint SB_BOTTOM = 7;
        private const uint SB_ENDSCROLL = 8;
        public RichTextBoxX()
        {
            this.ScrollBars = RichTextBoxScrollBars.None;
            this.MouseWheel += Me_MouseWheel;
        }
        private void Me_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    // Scrolls down
                    SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, IntPtr.Zero);
                }
                else
                {
                    // Scrolls up
                    SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, IntPtr.Zero);
                }
            }
            catch
            {
            }
        }
    }
