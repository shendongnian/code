    using System;
    using System.IO;
    using System.Linq;
    using OtexReportingRef.OtexReader.Interfaces;
    public class CsvFileColumnTrimmer:ICsvFileColumnTrimmer
    {
        public void TrimmColumns(ref StreamReader reader)
        {
            var columns = reader.ReadLine();
            if (columns != null)
            {
                columns = string.Join(";", columns.Split(';').Select(str => str.Trim()).ToArray());
                var res = columns + reader.ReadToEnd();
                var stream = WriteStringToStream(res);
                reader = new StreamReader(stream);
            }
            else
            {
                throw new ArgumentException("Host file is empty");
            }
        }
        
        public StreamReader TrimmColumns(StreamReader reader)
        {
            using (reader)
            {
                var columns = reader.ReadLine();
                if (columns != null)
                {
                    columns = string.Join(";", columns.Split(';').Select(str => str.Trim()).ToArray());
                    var res = columns + reader.ReadToEnd();
                    var stream = WriteStringToStream(res);
                    return new StreamReader(stream);
                }
                else
                {
                    throw new ArgumentException("Host file is empty");
                }
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
