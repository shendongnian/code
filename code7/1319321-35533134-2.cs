    using System.Runtime.InteropServices;
    /* ... */
    public void TImageReceived(IntPtr buf, int width, int height)
    {
        var length = height * width;
        var bytes = new byte[length];
        Marshal.Copy(buf, bytes, 0, length);
        // etc.
    }
