    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    namespace Utilities
    {
        // largely credited to http://stackoverflow.com/a/112711/3838199 for the image-specific code
        public static class ImageUtilities
        {
            private const string ErrorMessage = "Could not read image data";
            private const int ChunkSize = 1024;
            private static readonly Dictionary<byte[], Func<BinaryReader, Size>> ImageFormatDecoders = new Dictionary<byte[], Func<BinaryReader, Size>>()
            {
                { new byte[]{ 0x42, 0x4D }, DecodeBitmap},
                { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, DecodeGif },
                { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, DecodeGif },
                { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, DecodePng },
                { new byte[]{ 0xff, 0xd8 }, DecodeJfif },
            };
            /// <summary>
            /// Retrieve the dimensions of an online image, downloading as little as possible
            /// </summary>
            public static Size GetWebDimensions(Uri uri)
            {
                var moreBytes = true;
                var currentStart = 0;
                byte[] allBytes = { };
                while (moreBytes)
                {
                    try
                    {
                        var newBytes = GetSomeBytes(uri, currentStart, currentStart + ChunkSize - 1);
                        if (newBytes.Length < ChunkSize) moreBytes = false;
                        allBytes = Combine(allBytes, newBytes);
                        return GetDimensions(new BinaryReader(new MemoryStream(allBytes)));
                    }
                    catch
                    {
                        currentStart += ChunkSize;
                    }
                }
                return new Size(0, 0);
            }
            private static byte[] GetSomeBytes(Uri uri, int startRange, int endRange)
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage { RequestUri = uri };
                    request.Headers.Range = new RangeHeaderValue(startRange, endRange);
                    try
                    {
                        var response = client.SendAsync(request).Result;
                        return response.Content.ReadAsByteArrayAsync().Result;
                    }
                    catch { }
                }
                return new byte[] { };
            }
            /// <summary>
            /// Gets the dimensions of an image.
            /// </summary>
            /// <returns>The dimensions of the specified image.</returns>
            /// <exception cref="ArgumentException">The image was of an unrecognized format.</exception>    
            public static Size GetDimensions(BinaryReader binaryReader)
            {
                int maxMagicBytesLength = ImageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;
                byte[] magicBytes = new byte[maxMagicBytesLength];
                for (int i = 0; i < maxMagicBytesLength; i += 1)
                {
                    magicBytes[i] = binaryReader.ReadByte();
                    foreach (var kvPair in ImageFormatDecoders)
                    {
                        if (magicBytes.StartsWith(kvPair.Key))
                        {
                            return kvPair.Value(binaryReader);
                        }
                    }
                }
                throw new ArgumentException(ErrorMessage, nameof(binaryReader));
            }
            // from http://stackoverflow.com/a/415839/3838199
            private static byte[] Combine(byte[] first, byte[] second)
            {
                byte[] ret = new byte[first.Length + second.Length];
                Buffer.BlockCopy(first, 0, ret, 0, first.Length);
                Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
                return ret;
            }
            private static bool StartsWith(this byte[] thisBytes, byte[] thatBytes)
            {
                for (int i = 0; i < thatBytes.Length; i += 1)
                {
                    if (thisBytes[i] != thatBytes[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            private static short ReadLittleEndianInt16(this BinaryReader binaryReader)
            {
                byte[] bytes = new byte[sizeof(short)];
                for (int i = 0; i < sizeof(short); i += 1)
                {
                    bytes[sizeof(short) - 1 - i] = binaryReader.ReadByte();
                }
                return BitConverter.ToInt16(bytes, 0);
            }
            private static int ReadLittleEndianInt32(this BinaryReader binaryReader)
            {
                byte[] bytes = new byte[sizeof(int)];
                for (int i = 0; i < sizeof(int); i += 1)
                {
                    bytes[sizeof(int) - 1 - i] = binaryReader.ReadByte();
                }
                return BitConverter.ToInt32(bytes, 0);
            }
            private static Size DecodeBitmap(BinaryReader binaryReader)
            {
                binaryReader.ReadBytes(16);
                int width = binaryReader.ReadInt32();
                int height = binaryReader.ReadInt32();
                return new Size(width, height);
            }
            private static Size DecodeGif(BinaryReader binaryReader)
            {
                int width = binaryReader.ReadInt16();
                int height = binaryReader.ReadInt16();
                return new Size(width, height);
            }
            private static Size DecodePng(BinaryReader binaryReader)
            {
                binaryReader.ReadBytes(8);
                int width = binaryReader.ReadLittleEndianInt32();
                int height = binaryReader.ReadLittleEndianInt32();
                return new Size(width, height);
            }
            private static Size DecodeJfif(BinaryReader binaryReader)
            {
                while (binaryReader.ReadByte() == 0xff)
                {
                    byte marker = binaryReader.ReadByte();
                    short chunkLength = binaryReader.ReadLittleEndianInt16();
                    if (marker == 0xc0 || marker == 0xc1 || marker == 0xc2)
                    {
                        binaryReader.ReadByte();
                        int height = binaryReader.ReadLittleEndianInt16();
                        int width = binaryReader.ReadLittleEndianInt16();
                        return new Size(width, height);
                    }
                    binaryReader.ReadBytes(chunkLength - 2);
                }
                throw new ArgumentException(ErrorMessage);
            }
        }
    }
