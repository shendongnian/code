    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("Apogee.dll.dll")]
            extern static int CreateInstance(out IntPtr ICamera2Ptr);
            [DllImport("Apogee.dll.dll")]
            extern static void GetImage(ref IntPtr pImageBuffer);
            static void Main(string[] args)
            {
                IntPtr ICamera2Ptr;
                int results = CreateInstance(out ICamera2Ptr);
            }
            static UInt16[] getImage(int width, int height)
            {
                // Allocating array of image size (width * height)
                // where pixel is size of unsigned int (4 BYTES)
                // possible values: 0 to 4,294,967,295 
                // Allocate memory and calculate a byte count 
                //unsigned short *pBuffer = new unsigned short[ ImgXSize * ImgYSize ];
                //unsigned long ImgSizeBytes = ImgXSize * ImgYSize * 2; 
                UInt16[] pixels = new UInt16[width * height];
                IntPtr unmanaged_pPixels = Marshal.AllocHGlobal(Marshal.SizeOf(pixels));
                //// External operations ApogeeCamera->ExternalShutter = true; 
                //ApogeeCamera->ExternalIoReadout = false; 
                //ApogeeCamera->IoPortAssignment = 0x08; 
                // Even though the exposure time will not be used, still call Expose 
                //ApogeeCamera->Expose( 0.001, true ); 
                // Check camera status to make sure image data is ready 
                //while (ApogeeCamera->ImagingStatus != Apn_Status_ImageReady ); 
                // Get the image data from the camera ApogeeCamera->GetImage( (long)pBuffer );
                GetImage(ref unmanaged_pPixels);
                pixels = (UInt16[])Marshal.PtrToStructure(unmanaged_pPixels, typeof(UInt16[]));
                return pixels;
            }
        }
    }
    ​
