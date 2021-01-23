    using( Graphics g = Graphics.FromHwnd(IntPtr.Zero) )
    {
         SizeF size = g.MeasureString("some text", SystemFonts.DefaultFont);
    }
 
