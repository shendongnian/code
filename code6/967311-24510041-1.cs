    using System.IO;
    using NUnit.Framework;
    using OtexReportingRef.OtexReader.Implementation;
    [TestFixture]
    public class CsvFileColumnTrimmerTest
    {
        private const string Columns =
            "col1;col2        ;col3      ;";
        [Test]
        public void TrimColumns_Test()
        {
            var stream = WriteStringToStream(Columns);
            var streamReader = new StreamReader(stream);
            var trimmer = new CsvFileColumnTrimmer();
            trimmer.TrimmColumns(ref streamReader);
            var res = streamReader.ReadLine();
            Assert.AreEqual("col1;col2;col3;",res);
        } 
        [Test]
        public void TrimColumns_WithUsing_Test()
        {
            var stream = WriteStringToStream(Columns);
            using (var streamReader = new StreamReader(stream))
            {
                var trimmer = new CsvFileColumnTrimmer();
                using (var reader = trimmer.TrimmColumns(streamReader))
                {
                    var res = reader.ReadLine();
                    Assert.AreEqual("col1;col2;col3;", res);
                }
            }
        }
        
        [Test]
        public void TrimColumns_WithTryCatch_Test()
        {
            var stream = WriteStringToStream(Columns);
            var streamReader = new StreamReader(stream);
            try
            {
                var trimmer = new CsvFileColumnTrimmer();
                trimmer.TrimmColumns(ref streamReader);
                var res = streamReader.ReadLine();
                Assert.AreEqual("col1;col2;col3;", res);
            }
            finally 
            {
                streamReader.Dispose();
            }
        }
        private static MemoryStream WriteStringToStream(string res)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            streamWriter.Write(res);
            streamWriter.Flush();
            stream.Position = 0;
            return stream;
        }
    }
