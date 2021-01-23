    public struct trace_record
    {
        // you can create array here, but you will need to create in manually
        public byte tr_id_1; // 2 bytes
        public byte tr_id_2;
        
        public UInt16 tr_task;       //2 bytes
        public UInt16 tr_process;    //2 bytes
        public UInt16 tr_varies;     //2 bytes
        public UInt64 tr_time; //8 bytes
    }
    public static List<trace_record> ReadRecords(string fileName)
    {
        var result = new List<trace_record>();
        // store FileStream to check current position
        using (FileStream s = File.OpenRead(fileName))
        // and BinareReader to read values
        using (BinaryReader r = new BinaryReader(s))
        {
            // stop when reached the file end
            while (s.Position < s.Length)
            {
                try
                {
                    trace_record rec = new trace_record();
                    // or read two bytes and use an array instead of two separate bytes.
                    rec.tr_id_1 = r.ReadByte();
                    rec.tr_id_2 = r.ReadByte();
                    rec.tr_task = r.ReadUInt16();
                    rec.tr_process = r.ReadUInt16();
                    rec.tr_varies = r.ReadUInt16();
                    rec.tr_time = r.ReadUInt64();
                    result.Add(rec);
                }
                catch
                {
                    // handle unexpected end of file somehow.
                }
            }
            return result;
        }
    }
    static void Main()
    {
        var result = ReadRecords("d:\\in.txt");
        // get all records by condition
        var filtered = result.Where(r => r.tr_id_1 == 0x42);
        
        Console.ReadKey();
    }
