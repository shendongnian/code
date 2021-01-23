    class ImageMetadata
    {
        public static void SetImageMetadata(string imagesFolderPath)
        {
            string originalPath = @"C:\Users\test\Desktop\test.jpg";
            string outputPath = Environment.CurrentDirectory + @"\output.jpg";
            string finalPath = Environment.CurrentDirectory + @"\output_beforeInPlaceBitmapMetadataWriter.jpg";
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
            uint paddingAmount = 2048; // 2Kb padding for this example, but really this can be any value. 
            // Our recommendation is to keep this between 1Kb and 5Kb as most metadata updates are not large.
            // High level overview:
            //   1. Perform a lossles transcode on the JPEG
            //   2. Add appropriate padding
            //   3. Optionally add whatever metadata we need to add initially
            //   4. Save the file
            //   5. For sanity, we verify that we really did a lossless transcode
            //   6. Open the new file and add metadata in-place
            using (Stream originalFile = File.Open(originalPath, FileMode.Open, FileAccess.Read))
            {
                // Notice the BitmapCreateOptions and BitmapCacheOption. Using these options in the manner here
                // will inform the JPEG decoder and encoder that we're doing a lossless transcode operation. If the
                // encoder is anything but a JPEG encoder, then this no longer is a lossless operation.
                // ( Details: Basically BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile 
                //   tell the decoder to use the original image bits and BitmapCacheOption.None tells the decoder to wait 
                //   with decoding. So, at the time of encoding the JPEG encoder understands that the input was a JPEG
                //   and just copies over the image bits without decompressing and recompressing them. Hence, this is a
                //   lossless operation. )
                BitmapDecoder original = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);
                if (!original.CodecInfo.FileExtensions.Contains("jpg"))
                {
                    Console.WriteLine("The file you passed in is not a JPEG.");
                    return;
                }
                JpegBitmapEncoder output = new JpegBitmapEncoder();
                // If you're just interested in doing a lossless transcode without adding metadata, just do this:
                //output.Frames = original.Frames;
                // If you want to add metadata to the image using the InPlaceBitmapMetadataWriter, first add padding:
                if (original.Frames[0] != null && original.Frames[0].Metadata != null)
                {
                    // Your gut feel may want you to do something like:
                    //     output.Frames = original.Frames;
                    //     BitmapMetadata metadata = output.Frames[0].Metadata as BitmapMetadata;
                    //     if (metadata != null)
                    //     {
                    //         metadata.SetQuery("/app1/ifd/PaddingSchema:Padding", paddingAmount);
                    //     }
                    // However, the BitmapMetadata object is frozen. So, you need to clone the BitmapMetadata and then
                    // set the padding on it. Lastly, you need to create a "new" frame with the updated metadata.
                    BitmapMetadata metadata = original.Frames[0].Metadata.Clone() as BitmapMetadata;
                    // Of the metadata handlers that we ship in WIC, padding can only exist in IFD, EXIF, and XMP.
                    // Third parties implementing their own metadata handler may wish to support IWICFastMetadataEncoder
                    // and hence support padding as well.
                    metadata.SetQuery("/app1/ifd/PaddingSchema:Padding", paddingAmount);
                    metadata.SetQuery("/app1/ifd/exif/PaddingSchema:Padding", paddingAmount);
                    metadata.SetQuery("/xmp/PaddingSchema:Padding", paddingAmount);
                    // Since you're already adding metadata now, you can go ahead and add metadata up front.
                    metadata.SetQuery("/app1/ifd/{uint=897}", "hello there");
                    metadata.SetQuery("/app1/ifd/{uint=898}", "this is a test");
                    metadata.Title = "This is a title";
                    // Create a new frame identical to the one from the original image, except the metadata will have padding.
                    // Essentially we want to keep this as close as possible to:
                    //     output.Frames = original.Frames;
                    output.Frames.Add(BitmapFrame.Create(original.Frames[0], original.Frames[0].Thumbnail, metadata, original.Frames[0].ColorContexts));
                }
                using (Stream outputFile = File.Open(outputPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    output.Save(outputFile);
                }
            }
            // For sanity, let's verify that the original and the output contain image bits that are the same.
            using (Stream originalFile = File.Open(originalPath, FileMode.Open, FileAccess.Read))
            {
                BitmapDecoder original = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);
                using (Stream savedFile = File.Open(outputPath, FileMode.Open, FileAccess.Read))
                {
                    BitmapDecoder output = BitmapDecoder.Create(savedFile, createOptions, BitmapCacheOption.None);
                    Compare(original.Frames[0], output.Frames[0], 0, "foo", Console.Out);
                }
            }
            // Let's copy the file before we use the InPlaceBitmapMetadataWriter so that you can verify the metadata changes.
            File.Copy(outputPath, finalPath, true);
            Console.WriteLine();
            // Now let's use the InPlaceBitmapMetadataWriter.
            using (Stream savedFile = File.Open(outputPath, FileMode.Open, FileAccess.ReadWrite))
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                BitmapDecoder output = BitmapDecoder.Create(savedFile, BitmapCreateOptions.None, BitmapCacheOption.Default);
                InPlaceBitmapMetadataWriter metadata = output.Frames[0].CreateInPlaceBitmapMetadataWriter();
                // Within the InPlaceBitmapMetadataWriter, you can add, update, or remove metadata.
                //metadata.SetQuery("/app1/ifd/{uint=899}", "this is a test of the InPlaceBitmapMetadataWriter");
                //metadata.RemoveQuery("/app1/ifd/{uint=898}");
                //metadata.SetQuery("/app1/ifd/{uint=897}", "Hello there!!");
                Console.WriteLine("#####################");
                Console.WriteLine(metadata.GetQuery(@"/app13/irb/8bimiptc/iptc/City"));
                Console.WriteLine("#####################");
                metadata.SetQuery(@"/app13/irb/8bimiptc/iptc/Headline", "TEst");
                metadata.SetQuery(@"/app13/irb/8bimiptc/iptc/City", "TEst");
                metadata.SetQuery(@"/app13/irb/8bimiptc/iptc/CountryPrimaryLocationName", "TEst");
                metadata.SetQuery(@"/app13/irb/8bimiptc/iptc/ByLine", "TEst");
                metadata.SetQuery(@"/app13/irb/8bimiptc/iptc/CaptionAbstract", "TEst");
                Console.WriteLine("#####################");
                Console.WriteLine(metadata.GetQuery(@"/app13/irb/8bimiptc/iptc/City"));
                Console.WriteLine("#####################");
                if (metadata.TrySave())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("InPlaceMetadataWriter succeeded!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("InPlaceMetadataWriter failed!");
                }
                Console.ForegroundColor = originalColor;
            }
            FileInfo originalInfo = new FileInfo(originalPath);
            FileInfo outputInfo = new FileInfo(outputPath);
            FileInfo finalInfo = new FileInfo(finalPath);
            Console.WriteLine(outputPath);
            Console.WriteLine();
            Console.WriteLine("Original File Size: \t\t\t{0}", originalInfo.Length);
            Console.WriteLine("After Padding File Size: \t\t{0}", outputInfo.Length);
            Console.WriteLine("After InPlaceBitmapWriter File Size: \t{0}", finalInfo.Length);
        }
        /// <summary>
        /// Compares 2 BitmapSources. Basically a poor man's image comparison routine.
        /// </summary>
        /// <param name="originalImage">Original BitmapSource</param>
        /// <param name="resultImage">Result BitmapSource</param>
        /// <param name="tolerance">Tolerance to use for determining a fail</param>
        /// <param name="errorFilename">Filename prefix for the output files if a fail is detected</param>
        /// <param name="log">Where to log the results to</param>
        /// <returns>true is BitmapSources are within tolerance; false otherwise</returns>
        private static bool Compare(BitmapSource originalImage, BitmapSource resultImage, byte tolerance, string errorFilename, TextWriter log)
        {
            bool result = true;
            if (originalImage.PixelWidth != resultImage.PixelWidth)
            {
                log.WriteLine("\t\t\tBitmap widths are not equal.");
                return false;
            }
            if (originalImage.PixelHeight != resultImage.PixelHeight)
            {
                log.WriteLine("\t\t\tBitmap heights are not equal.");
                return false;
            }
            if (originalImage.Format != resultImage.Format)
            {
                log.WriteLine("\t\t\tBitmap pixel formats are not equal.");
                return false;
            }
            System.Windows.Media.PixelFormat pf = PixelFormats.Bgra32;
            FormatConvertedBitmap src0 = new FormatConvertedBitmap(originalImage, pf, null, 0);
            FormatConvertedBitmap src1 = new FormatConvertedBitmap(resultImage, pf, null, 0);
            GC.AddMemoryPressure(((src0.Format.BitsPerPixel * src0.PixelWidth + 7) / 8) * src0.PixelHeight);
            GC.AddMemoryPressure(((src1.Format.BitsPerPixel * src1.PixelWidth + 7) / 8) * src1.PixelHeight);
            int width = src0.PixelWidth;
            int height = src0.PixelHeight;
            int bpp = pf.BitsPerPixel;
            int stride = (bpp * width + 7) / 8;
            byte[] scanline0 = new byte[stride];
            byte[] scanline1 = new byte[stride];
            Int32Rect lineRect = new Int32Rect(0, 0, width, 1);
            log.WriteLine("Comparison progress...");
            for (int y = 0; y < height; y++)
            {
                if (y % 15 == 0)
                {
                    log.Write("{0}, ", y);
                }
                lineRect.Y = y;
                src0.CopyPixels(lineRect, scanline0, stride, 0);
                src1.CopyPixels(lineRect, scanline1, stride, 0);
                for (int b = 0; b < stride; b++)
                {
                    if (Math.Abs(scanline0[b] - scanline1[b]) > tolerance)
                    {
                        // log.WriteLine(string.Format("\t\t\tBitmap pixels are not equal (y = {0})", y));
                        log.WriteLine(string.Format("\t\t\tExpected {0}, Found {1}, Tolerance {2}", scanline0[b], scanline1[b], tolerance));
                        result = false;
                    }
                }
            }
            log.WriteLine();
            src0 = null;
            src1 = null;
            scanline0 = null;
            scanline1 = null;
            if (!result)
            {
                using (Stream stm = File.Create(errorFilename + ".original.png"))
                {
                    PngBitmapEncoder png = new PngBitmapEncoder();
                    png.Frames.Add(BitmapFrame.Create(originalImage));
                    png.Save(stm);
                }
                using (Stream stm = File.Create(errorFilename + ".result.png"))
                {
                    PngBitmapEncoder png = new PngBitmapEncoder();
                    png.Frames.Add(BitmapFrame.Create(resultImage));
                    png.Save(stm);
                }
            }
            return result;
        }
    }
