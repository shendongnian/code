        public static Cursor CreateCursor(Bitmap bm, int xHotspot, int yHotspot, bool resize = true)
        {
            IntPtr ptr = (resize) ? ((Bitmap)ResizeBitmap(bm, 32, 32)).GetHicon() : bm.GetHicon();
            IconInfo inf = new IconInfo();
            GetIconInfo(ptr, ref inf);
            inf.xHotspot = xHotspot;
            inf.yHotspot = yHotspot;
            inf.fIcon = false;
            IntPtr cursorPtr = CreateIconIndirect(ref inf);
            if (inf.hbmColor != IntPtr.Zero) { DeleteObject(inf.hbmColor); }
            if (inf.hbmMask != IntPtr.Zero) { DeleteObject(inf.hbmMask); }
            if (ptr != IntPtr.Zero) { DestroyIcon(ptr); }
            Cursor c = new Cursor(cursorPtr);
            c.Tag = (resize) ? new Size(32, 32) : bm.Size;
            return c;
        }
