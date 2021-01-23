    class Program
    {
        [DllImport("msi.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);
        [DllImport("msi.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        static extern int MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);
        [DllImport("msi.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        static extern int MsiGetFileSignatureInformation(string fileName, int flags, out IntPtr certContext, IntPtr hashData, ref int hashDataLength);
        [DllImport("Crypt32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        static extern int CertFreeCertificateContext( IntPtr certContext );
        [DllImport("Crypt32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        static extern int CertGetNameString(IntPtr certContext, UInt32 type, UInt32 flags, IntPtr typeParameter, StringBuilder stringValue, UInt32 stringLength );
        static void Main(string[] args)
        {
            int index = 0;
            StringBuilder productCode = new StringBuilder();
            int result = MsiEnumProducts(index, productCode);
            while (result == 0)
            {
                Console.WriteLine("{0}", productCode);
                Int32 length = 1024;
                StringBuilder fileName = new StringBuilder();
                result = MsiGetProductInfo(
                            productCode.ToString(),
                            "LocalPackage",
                            fileName,
                            ref length );
                if (result == 0)
                {
                    Console.WriteLine("{0}", fileName);
                    IntPtr certContext = IntPtr.Zero;
                    IntPtr hashData = IntPtr.Zero;
                    int hashDataLength = 0;
                    result = MsiGetFileSignatureInformation(
                                fileName.ToString(),
                                0,
                                out certContext,
                                hashData,
                                ref hashDataLength);
                    if ( result == 0 )
                    {
                        Console.WriteLine("Got Cert");
                        StringBuilder simpleDisplayType = new StringBuilder();
                        int ok = CertGetNameString(
                                    certContext,
                                    4,                      // == CERT_NAME_SIMPLE_DISPLAY_TYPE
                                    0,
                                    IntPtr.Zero,
                                    simpleDisplayType,
                                    1024 );
                        if (ok != 0)
                        {
                            Console.WriteLine("{0}", simpleDisplayType);
                        }
                        CertFreeCertificateContext(certContext);
                    }
                }
                ++index;
                result = MsiEnumProducts(index, productCode);
            }
        }
    }
