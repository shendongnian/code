    public Bitmap RtbToBitmap(RichTextBox rtb)
    {
        Bitmap bmp = // Load your Image here
        using (Graphics gr = Graphics.FromImage(bmp))
        {
            // gr.Clear(Color.Black); // Don't clear it with black
            System.IntPtr hDC = gr.GetHdc(); // 屏幕做为画源
            FORMATRANGE fmtRange;
            RECT rect;
            int fromAPI;
            float inch = 100F;
            rect.Top = 10; 
            rect.Left = 10;
            rect.Bottom = (int)(bmp.Height + (bmp.Height * (bmp.HorizontalResolution / 100)) * inch);
            rect.Right = bmp.Width * 15;
            fmtRange.chrg.cpMin = 0;
            fmtRange.chrg.cpMax = -1;
            fmtRange.hdc = hDC;
            fmtRange.hdcTarget = hDC;
            fmtRange.rc = rect;
            fmtRange.rcPage = rect;
            int wParam = 1;
            System.IntPtr lParam = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            System.Runtime.InteropServices.Marshal.StructureToPtr(fmtRange, lParam, false);
            fromAPI = SendMessage(rtb.Handle, EM_FORMATRANGE, wParam, lParam);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(lParam);
            fromAPI = SendMessage(rtb.Handle, EM_FORMATRANGE, wParam, new IntPtr(0));
            gr.ReleaseHdc(hDC);
        }
        return bmp;
    }
