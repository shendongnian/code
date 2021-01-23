    [FixedLengthRecord(FixedMode.AllowLessChars)]
    class File_load
    {
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        public string proj_name;
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        public string iso;
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        public string line;
        [FieldFixedLength(1000)]
        [FieldTrim(TrimMode.Right)]
        public string pid;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<File_load>();
            
            var records = engine.ReadString(
               "112233444444" + Environment.NewLine +
               "1122334"
            );
            var firstRecord = records[0];
            Assert.AreEqual("11", firstRecord.proj_name);
            Assert.AreEqual("22", firstRecord.iso);
            Assert.AreEqual("33", firstRecord.line);
            Assert.AreEqual("444444", firstRecord.pid);
            var secondRecord = records[1];
            Assert.AreEqual("11", secondRecord.proj_name);
            Assert.AreEqual("22", secondRecord.iso);
            Assert.AreEqual("33", secondRecord.line);
            Assert.AreEqual("4", secondRecord.pid);
            Console.Read();
        }
    }
