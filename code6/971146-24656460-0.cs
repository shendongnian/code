        [ComImport, Guid("327ABDA7-072B-11D3-9D7B-0000F81EF32E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComVisible(true)]
		public interface IImagingFactory
		{
			uint CreateImageFromStream();       // This is a place holder, note the lack of arguments
			uint CreateImageFromFile(string filename, out IImage image);
			// We need the MarshalAs attribute here to keep COM interop from sending the buffer down as a Safe Array.
			uint CreateImageFromBuffer([MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint size, BufferDisposalFlag disposalFlag, out IImage image);
			uint CreateNewBitmap(uint width, uint height, PixelFormatID pixelFormat, out IBitmapImage bitmap);
			uint CreateBitmapFromImage(IImage image, uint width, uint height, PixelFormatID pixelFormat, InterpolationHint hints, out IBitmapImage bitmap);
			uint CreateBitmapFromBuffer();      // This is a place holder, note the lack of arguments
			uint CreateImageDecoder();          // This is a place holder, note the lack of arguments
			uint CreateImageEncoderToStream();  // This is a place holder, note the lack of arguments
			uint CreateImageEncoderToFile();    // This is a place holder, note the lack of arguments
			uint GetInstalledDecoders();        // This is a place holder, note the lack of arguments
			uint GetInstalledEncoders();        // This is a place holder, note the lack of arguments
			uint InstallImageCodec();           // This is a place holder, note the lack of arguments
			uint UninstallImageCodec();         // This is a place holder, note the lack of arguments
		}
