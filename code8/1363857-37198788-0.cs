    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using Interop;
    using System.Runtime.InteropServices;
    using stdole;
    namespace QRCoder
    {
    [Guid("52724C82-F18C-460B-B48D-1F19E016F86E")]
    [ComVisible (true) , InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IQRCodeGene
    {
        string Create(string text, QRCodeGenerator.ECCLevel value, int pixelsPerModule);
    }
    [Guid("4F445AA5-D642-438B-A69A-429D621A3CB0")]
    [ComVisible (true), ClassInterface(ClassInterfaceType.None)]
       public class QRCodeGene: IQRCodeGene, IDisposable
    {
        private QRCodeGenerator Instance;
        public QRCodeGene()
        {
            Instance = new QRCodeGenerator();
        }
        public string Create(string text, QRCodeGenerator.ECCLevel value, int pixelsPerModule)
        {
            var qrCodeData = Instance.CreateQrCode(text, value);
            var qrCode = new QRCode(qrCodeData);
            var bitmap = qrCode.GetGraphic(pixelsPerModule);
    // This line is the only modified by the provided in the code above.
            bitmap.Save("C:\\"+text+".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
    //I return this string for testing. I guess If removed the text wouldn't work.
            return ("Hello");
        }
        public void Dispose()
        {
            Instance.Dispose();
        }
    }
    }
