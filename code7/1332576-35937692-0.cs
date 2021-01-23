    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication81
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError=true)]
            static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,[Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
            const int SIZE = 268435457;
            static void Main(string[] args)        
            {
                Process[] P = Process.GetProcessesByName("example");
                if (P.Length == 0)
                {
                    return -1;
                }
                if (modules == exmaple())
                {
                    modules = P[0].MainModule.BaseAddress;
                }
                IntPtr buffer = Marshal.AllocHGlobal(SIZE);
                var tempVar = 0;
                ReadProcessMemory(P[0].Handle, modules, out buffer, SIZE, ref tempVar);
                byte[] _Buffer = new byte[SIZE];
                Marshal.PtrToStructure(buffer, _Buffer);
                int[] sBytes = new int[256];
                int Len = Pattern.Length - 1;
                var Dex = 0;
                for (int i = 255; i >= 0; i--)
                {
                    sBytes[i] = Pattern.Length;
                }
                for (int i = Len; i >= 0; i--)
                {
                    sBytes[Pattern[i]] = Len;
                }
                while (Dex <= _Buffer.Length - Pattern.Length)
                {
                    int i = Len;
                    while (_Buffer[Dex + i] == Pattern[i])
                    {
                        if (i == 0)
                        {
                            return Dex;
                        }
                        i -= 1;
                    }
                    Dex += sBytes[_Buffer[Dex + Len]];
                }
                return -1;
     
            }
        }
    }
