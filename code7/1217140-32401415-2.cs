    public class RichTextBoxEx : RichTextBox
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_CHARRANGE
        {
            public Int32 cpMin;
            public Int32 cpMax;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public STRUCT_RECT rc;
            public STRUCT_RECT rcPage;
            public STRUCT_CHARRANGE chrg;
        }
    
        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);
    
        private const Int32 WM_USER = 0x400;
        private const Int32 EM_FORMATRANGE = WM_USER + 57;
        private const Int32 EM_GETCHARFORMAT = WM_USER + 58;
        private const Int32 EM_SETCHARFORMAT = WM_USER + 68;
    
        /// <summary>
        /// Calculate or render the contents of our RichTextBox for printing
        /// </summary>
        /// <param name="measureOnly">If true, only the calculation is performed, otherwise the text is rendered as well</param>
        /// <param name="e">The PrintPageEventArgs object from the PrintPage event</param>
        /// <param name="charFrom">Index of first character to be printed</param>
        /// <param name="charTo">Index of last character to be printed</param>
        /// <returns> (Index of last character that fitted on the page) + 1</returns>
        public int FormatRange(bool measureOnly, PrintPageEventArgs e, int charFrom, int charTo)
        {
            // Specify which characters to print
            STRUCT_CHARRANGE cr = default(STRUCT_CHARRANGE);
            cr.cpMin = charFrom;
            cr.cpMax = charTo;
    
            // Specify the area inside page margins
            STRUCT_RECT rc = default(STRUCT_RECT);
            rc.top = HundredthInchToTwips(e.MarginBounds.Top);
            rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom);
            rc.left = HundredthInchToTwips(e.MarginBounds.Left);
            rc.right = HundredthInchToTwips(e.MarginBounds.Right);
    
            // Specify the page area
            STRUCT_RECT rcPage = default(STRUCT_RECT);
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top);
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom);
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left);
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right);
    
            // Get device context of output device
            IntPtr hdc = default(IntPtr);
            hdc = e.Graphics.GetHdc();
    
            // Fill in the FORMATRANGE structure
            STRUCT_FORMATRANGE fr = default(STRUCT_FORMATRANGE);
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;
    
            // Non-Zero wParam means render, Zero means measure
            Int32 wParam = default(Int32);
            if (measureOnly)
            {
                wParam = 0;
            }
            else
            {
                wParam = 1;
            }
    
            // Allocate memory for the FORMATRANGE struct and
            // copy the contents of our struct to this memory
            IntPtr lParam = default(IntPtr);
            lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lParam, false);
    
            // Send the actual Win32 message
            int res = 0;
            res = SendMessage(Handle, EM_FORMATRANGE, wParam, lParam);
    
            // Free allocated memory
            Marshal.FreeCoTaskMem(lParam);
    
            // and release the device context
            e.Graphics.ReleaseHdc(hdc);
    
            return res;
        }
    
        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework)
        /// and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        private Int32 HundredthInchToTwips(int n)
        {
            return Convert.ToInt32(n * 14.4);
        }
    
        /// <summary>
        /// Free cached data from rich edit control after printing
        /// </summary>
        public void FormatRangeDone()
        {
            IntPtr lParam = new IntPtr(0);
            SendMessage(Handle, EM_FORMATRANGE, 0, lParam);
        }
    }
