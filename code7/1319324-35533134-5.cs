    using System.Runtime.InteropServices;
    /* ... */
    TImage image;
    /* ... */
    var length = image.Height * image.Width;
    var bytes = new byte[length];
    Marshal.Copy(image.Buf, bytes, 0, length);
