    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace redmasq {
       public static class ExcelFileFixExample {
            public static byte[] XLSXOpenOfficePackageFix(byte[] fileData) {
                using (MemoryStream ms = new MemoryStream(fileData, false)) {
                    using (ZipArchive za = new ZipArchive(ms)) {
                        using (MemoryStream ms2 = new MemoryStream()) {
                            using (ZipArchive za2 = new ZipArchive(ms2, ZipArchiveMode.Create)) {
                                foreach (ZipArchiveEntry entry in za.Entries) {
                                    ZipArchiveEntry zae = za2.CreateEntry(entry.FullName, System.IO.Compression.CompressionLevel.Optimal);
                                    using (Stream src = entry.Open()) {
                                        using (Stream dest = zae.Open()) {
                                            src.CopyTo(dest);
                                        }
                                    }
                                }
                            }
                            return ms2.ToArray();
                        }
                    }
                }
            }
       }
    }
