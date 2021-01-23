    public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
    {
    Graphics g;
    Bitmap v;
    v = new Bitmap(m_videoWidth, m_videoHeight, m_stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pBuffer);            
    g = Graphics.FromImage(v);
    CURSORINFO cursorInfo;
    cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
    
    if (GetCursorInfo(out cursorInfo))
    {
        if (cursorInfo.flags == CURSOR_SHOWING)
        {
            var iconPointer = CopyIcon(cursorInfo.hCursor);
            ICONINFO iconInfo;
            int iconX, iconY;
    
            if (GetIconInfo(iconPointer, out iconInfo))
            {
                iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);
                //DRAW STATIC POINTER IMAGE
                Bitmap pointerImage = new Bitmap('pointer.png');
                g.DrawImage(pointerImage,iconX,iconY);
                g.Dispose();
                v.Dispose();                        
            }
        }
    }
    return 0;
    }
