    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var len = Marshal.SizeOf(typeof(Inherited));
            var ofs = Marshal.OffsetOf(typeof(Inherited), "<Type>k__BackingField");
        }
    }
    public interface IBase {
        ushort Size { get; set; }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Inherited : IBase {
        public ushort Size { get; set; }
        public byte Type { get; set; }
    }
