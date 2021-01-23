    [Guid("C7CC4CA0-813A-431E-B92C-842A07735E72")]
    [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _QRCodeGenerator {
    
        public IStdPicture Create(string text, int cclevel, int pixelsPerModule);
        
    }
    
    
    [ProgId("QRCoder.QRCodeGenerator")]
    [Guid("4DC2C1F8-2727-4120-80E1-8475650D8547")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    [Description("...")]
    public class QRCodeGenerator : _QRCodeGenerator, IDisposable {
    
        private QRCoder.QRCodeGenerator instance;
        
        public QRCodeGenerator() {
            instance = new QRCoder.QRCodeGenerator();
        }
        
        public IStdPicture Create(string text, int cclevel, int pixelsPerModule){
            var qrCodeData = instance.CreateQrCode(text, cclevel);
            var qrCode = new QRCoder.QRCode(qrCodeData);
            var bitmap = qrCode.GetGraphic(pixelsPerModule);
            return ImageToPicture(bitmap);
        }
        
        public void Dispose() {
            instance.Dispose();
        }
        
        private static IStdPicture ImageToPicture(Bitmap bitmap) {
            ...
        }
    }
