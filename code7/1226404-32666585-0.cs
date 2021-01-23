    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows;
    using System.Runtime.InteropServices;
    
    namespace WpfRichTextBox._32648134
    {
        public class ImageCode
        {
            public static ImageSource ImageFromClipboardDibAsSource()
            {
                MemoryStream ms = Clipboard.GetData("DeviceIndependentBitmap") as MemoryStream;
                if (ms != null)
                {
                    byte[] dibBuffer = new byte[ms.Length];
                    ms.Read(dibBuffer, 0, dibBuffer.Length);
    
                    BITMAPINFOHEADER infoHeader =
                        BinaryStructConverter.FromByteArray<BITMAPINFOHEADER>(dibBuffer);
    
                    int fileHeaderSize = Marshal.SizeOf(typeof(BITMAPFILEHEADER));
                    int infoHeaderSize = infoHeader.biSize;
                    int fileSize = fileHeaderSize + infoHeader.biSize + infoHeader.biSizeImage;
    
                    BITMAPFILEHEADER fileHeader = new BITMAPFILEHEADER();
                    fileHeader.bfType = BITMAPFILEHEADER.BM;
                    fileHeader.bfSize = fileSize;
                    fileHeader.bfReserved1 = 0;
                    fileHeader.bfReserved2 = 0;
                    fileHeader.bfOffBits = fileHeaderSize + infoHeaderSize + infoHeader.biClrUsed * 4;
    
                    byte[] fileHeaderBytes =
                        BinaryStructConverter.ToByteArray<BITMAPFILEHEADER>(fileHeader);
    
                    MemoryStream msBitmap = new MemoryStream();
                    msBitmap.Write(fileHeaderBytes, 0, fileHeaderSize);
                    msBitmap.Write(dibBuffer, 0, dibBuffer.Length);
                    msBitmap.Seek(0, SeekOrigin.Begin);
                    
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.CacheOption = BitmapCacheOption.OnDemand;
                    img.CreateOptions = BitmapCreateOptions.DelayCreation;
                    img.StreamSource = msBitmap;
                    img.EndInit();
                    
                    return img;
                }
                return null;
            }
    
            public static MemoryStream ImageFromClipboardDibAsStream()
            {
                MemoryStream ms = Clipboard.GetData("DeviceIndependentBitmap") as MemoryStream;
                if (ms != null)
                {
                    byte[] dibBuffer = new byte[ms.Length];
                    ms.Read(dibBuffer, 0, dibBuffer.Length);
    
                    BITMAPINFOHEADER infoHeader =
                        BinaryStructConverter.FromByteArray<BITMAPINFOHEADER>(dibBuffer);
    
                    int fileHeaderSize = Marshal.SizeOf(typeof(BITMAPFILEHEADER));
                    int infoHeaderSize = infoHeader.biSize;
                    int fileSize = fileHeaderSize + infoHeader.biSize + infoHeader.biSizeImage;
    
                    BITMAPFILEHEADER fileHeader = new BITMAPFILEHEADER();
                    fileHeader.bfType = BITMAPFILEHEADER.BM;
                    fileHeader.bfSize = fileSize;
                    fileHeader.bfReserved1 = 0;
                    fileHeader.bfReserved2 = 0;
                    fileHeader.bfOffBits = fileHeaderSize + infoHeaderSize + infoHeader.biClrUsed * 4;
    
                    byte[] fileHeaderBytes =
                        BinaryStructConverter.ToByteArray<BITMAPFILEHEADER>(fileHeader);
    
                    MemoryStream msBitmap = new MemoryStream();
                    msBitmap.Write(fileHeaderBytes, 0, fileHeaderSize);
                    msBitmap.Write(dibBuffer, 0, dibBuffer.Length);
                    msBitmap.Seek(0, SeekOrigin.Begin);
    
                    return msBitmap;
                }
                return null;
            }
        }
    
        public static class BinaryStructConverter
        {
            public static T FromByteArray<T>(byte[] bytes) where T : struct
            {
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    int size = Marshal.SizeOf(typeof(T));
                    ptr = Marshal.AllocHGlobal(size);
                    Marshal.Copy(bytes, 0, ptr, size);
                    object obj = Marshal.PtrToStructure(ptr, typeof(T));
                    return (T)obj;
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptr);
                }
            }
    
            public static byte[] ToByteArray<T>(T obj) where T : struct
            {
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    int size = Marshal.SizeOf(typeof(T));
                    ptr = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(obj, ptr, true);
                    byte[] bytes = new byte[size];
                    Marshal.Copy(ptr, bytes, 0, size);
                    return bytes;
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptr);
                }
            }
        }
    
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
         struct BITMAPFILEHEADER
        {
            public static readonly short BM = 0x4d42; // BM
    
            public short bfType;
            public int bfSize;
            public short bfReserved1;
            public short bfReserved2;
            public int bfOffBits;
        }
    
        [StructLayout(LayoutKind.Sequential)]
         struct BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }
    
    }
