    using System;
    using System.Runtime.InteropServices;
    using System.IO.Pipes;
    namespace Pipes {
        // see https://msdn.microsoft.com/en-us/library/bb546085(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
        // for information on creating pipe clients and servers in c#
        class Program {
            [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
            public struct PipeHeader {
                [MarshalAs(UnmanagedType.I1)]
                public byte command;
                [MarshalAs(UnmanagedType.I4)]
                public Int32 sockid;
                public Int32 datasize;
            }
            static void Main(string[] args) {
                var pipename = "pipey";
                var pipeClient = new NamedPipeClientStream(pipename);
                Console.WriteLine("Connecting to server pipe '{0}'", pipename);
                pipeClient.Connect();
                var hdr = new PipeHeader();
                var hdrSize = Marshal.SizeOf(hdr);
                hdr.command = 1;
                hdr.sockid = 1912;
                hdr.datasize = 32;
                var buf = Serialize(hdr);
                Console.WriteLine("Writing to server pipe");
                pipeClient.Write(buf, 0, hdrSize);
                pipeClient.Read(buf, 0, hdrSize);
                hdr = (PipeHeader) Deserialize(buf, hdr.GetType());
                Console.WriteLine("Pipe read {{ command: {0}, sockid: {1}, datasize: {2} }}",
                                   hdr.command, hdr.sockid, hdr.datasize);
                hdr.command = 0; // tell server to disconnect
                buf = Serialize(hdr);
                Console.WriteLine("Sending disconnect");
                pipeClient.Write(buf, 0, hdrSize);
                pipeClient.Close();
                Console.WriteLine("Pipe closed");
                }
            public static object Deserialize(byte[] rawdatas, Type anytype) {
                int rawsize = Marshal.SizeOf(anytype);
                if (rawsize > rawdatas.Length)
                    return null;
                GCHandle handle = GCHandle.Alloc(rawdatas, GCHandleType.Pinned);
                IntPtr buffer = handle.AddrOfPinnedObject();
                object retobj = Marshal.PtrToStructure(buffer, anytype);
                handle.Free();
                return retobj;
                }
            public static byte[] Serialize(object obj) {
                int rawsize = Marshal.SizeOf(obj);
                var rv = new byte[rawsize];
                IntPtr ptr = Marshal.AllocHGlobal(rawsize);
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, rv, 0, rawsize);
                Marshal.FreeHGlobal(ptr);
                return rv;
                }
            }
        }
