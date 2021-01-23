    using System.Runtime.InteropServices;
        namespace Ivi.Visa.Interop
        {
            [...]
            public interface IFormattedIO488
    {
        [DispId(1610678274)]
        bool InstrumentBigEndian { get; set; }
        [DispId(1610678272)]
        IMessage IO { get; set; }
        void FlushRead();
        void FlushWrite(bool sendEND = false);
        dynamic ReadIEEEBlock(IEEEBinaryType type, bool seekToBlock = false, bool flushToEND = false);
        dynamic ReadList(IEEEASCIIType type = IEEEASCIIType.ASCIIType_Any, string listSeperator = ",;");
        dynamic ReadNumber(IEEEASCIIType type = IEEEASCIIType.ASCIIType_Any, bool flushToEND = false);
        string ReadString();
        void SetBufferSize(BufferMask mask, int size);
        void WriteIEEEBlock(string Command, object data, bool flushAndEND = false);
        void WriteList(ref object data, IEEEASCIIType type = IEEEASCIIType.ASCIIType_Any, string listSeperator = ",", bool flushAndEND = false);
        void WriteNumber(object data, IEEEASCIIType type = IEEEASCIIType.ASCIIType_Any, bool flushAndEND = false);
        void WriteString(string data, bool flushAndEND = false);
    }
} `
