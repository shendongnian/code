    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    namespace MemoryManagement
    {
        public class Memory : IDisposable
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);
            [DllImport("kernel32.dll")]
            static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            byte[] lpBuffer, UIntPtr nSize, uint lpNumberOfBytesWritten);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
    
    
            public IntPtr Handle;
            public Process ProcessHeld = null;
            public Memory(string sprocess)
            {
                Process[] Processes = Process.GetProcessesByName(sprocess);
                Process nProcess = Processes[0];
    
                Handle = OpenProcess(0x10, false, (uint)nProcess.Id);
                if (Handle != IntPtr.Zero)
                {
                    ProcessLoaded = true;
                    ProcessHeld = nProcess;
                }
                else
                {
                    ProcessLoaded = false;
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
    
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
            }
    
            // Use C# destructor syntax for finalization code.
    
            ~Memory()
            {
                Dispose(false);
            }
    
    
    
            //Would use this method below - for the actual writing of the Disable Patch Code 
            public UIntPtr WriteByteArray(IntPtr hProcess, IntPtr BaseAddress, byte[] NewVal)
            {
                try
                {
                    // Return Value 
                    bool ReturnVal;
                    UIntPtr BytesWritten;
                    // Write Memory Byte Array 
                    ReturnVal = WriteProcessMemory(hProcess, BaseAddress, NewVal, (uint)NewVal.Length, out BytesWritten);
    
                    return BytesWritten;
                }
                catch (Exception e)
                {
                    
                    return (UIntPtr)0x0;
                }
            } 
    
    
            public bool ProcessLoaded = false;
    
            public string ReadString(uint pointer)
            {
                byte[] bytes = new byte[24];
    
                ReadProcessMemory(Handle, (IntPtr)pointer, bytes, (UIntPtr)24, 0);
                return Encoding.UTF8.GetString(bytes);
            }
    
            public string ReadString(uint pointer, int length)
            {
                byte[] bytes = new byte[length];
    
                ReadProcessMemory(Handle, (IntPtr)pointer, bytes, (UIntPtr)length, 0);
                return Encoding.UTF8.GetString(bytes);
            }
    
            public int ReadOffset(uint pointer, uint offset)
            {
                byte[] bytes = new byte[24];
    
                uint adress = (uint)ReadPointer(pointer) + offset;
                ReadProcessMemory(Handle, (IntPtr)adress, bytes, (UIntPtr)sizeof(int), 0);
                return BitConverter.ToInt32(bytes, 0);
            }
    
            public int ReadPointer(uint pointer)
            {
                byte[] bytes = new byte[24];
    
                ReadProcessMemory(Handle, (IntPtr)pointer, bytes, (UIntPtr)sizeof(int), 0);
                return BitConverter.ToInt32(bytes, 0);
            }
    
        }
    
    }
