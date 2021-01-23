    using System;
    using System.Windows.Forms;
    using System.IO.MemoryMappedFiles;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace MyMemoryApplication
    {
        public partial class Form1 : Form
        {
            private struct UpdateInfoPacket
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
                public string JobName;
    
                public char Status;
    
                public int NumberOfFiles;
            }
    
            private MemoryMappedFile m_memMap = null;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                m_memMap = ConnectToMemoryMap("MyMemoryMapName");
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (m_memMap != null) m_memMap.Dispose();
            }
    
            private MemoryMappedFile ConnectToMemoryMap(string mapName)
            {
                MemoryMappedFile memMap = null;
                try
                {
                    memMap = MemoryMappedFile.OpenExisting(mapName);
                }
                catch (FileNotFoundException ex)
                {
                    if (ex.Message != "Unable to find the specified file.")
                    {
                        //BIG ERROR, report it
                        System.Diagnostics.Debug.WriteLine("Error " + ex.Message);
                    }
                    memMap = null;
                }
    
                //Create the memory map if needed
                try
                {
                    if (memMap == null)
                        memMap = MemoryMappedFile.CreateNew(mapName, 10000);
                }
                catch (Exception ex)
                {
                    //BIG ERROR, report it
                    System.Diagnostics.Debug.WriteLine("Error " + ex.Message);
    
                    memMap = null;
                }
    
                return memMap;
            }
    
            private int PacketSize()
            {
                UpdateInfoPacket packet = new UpdateInfoPacket();
                int size = Marshal.SizeOf(packet);
                return size;
            }
    
            private byte[] PacketToBytes(UpdateInfoPacket packet)
            {
                int size = Marshal.SizeOf(packet);
                byte[] array = new byte[size];
    
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(packet, ptr, true);
                Marshal.Copy(ptr, array, 0, size);
                Marshal.FreeHGlobal(ptr);
                return array;
            }
    
            private UpdateInfoPacket BytesToPacket(byte[] packet)
            {
                UpdateInfoPacket structure = new UpdateInfoPacket();
    
                int size = Marshal.SizeOf(structure);
                IntPtr ptr = Marshal.AllocHGlobal(size);
    
                Marshal.Copy(packet, 0, ptr, size);
    
                structure = (UpdateInfoPacket)Marshal.PtrToStructure(ptr, structure.GetType());
                Marshal.FreeHGlobal(ptr);
    
                return structure;
            }
    
            private void ReadMemoryMap(out UpdateInfoPacket packet)
            {
                packet = new UpdateInfoPacket();
    
                MemoryMappedViewStream memStream = null;
                try
                {
                    //Make sure there is a map first
                    if (m_memMap == null) return;
    
                    //Create the view stream
                    memStream = m_memMap.CreateViewStream();
                    memStream.Seek(0, SeekOrigin.Begin);
    
                    //Create the object to read from the memory map
                    using (BinaryReader reader = new BinaryReader(memStream))
                    {
                        //Read the data from memory in bytes
                        byte[] rawPacket = reader.ReadBytes(PacketSize());
    
                        //Convert the byte data to the structure
                        if (rawPacket != null) packet = BytesToPacket(rawPacket);
                    }
                }
                catch (Exception ex)
                {
                    //BIG ERROR, report it
                    System.Diagnostics.Debug.WriteLine("Error " + ex.Message);
                }
            }
    
            private void WriteMemoryMap(UpdateInfoPacket packet)
            {
                MemoryMappedViewStream memStream = null;
                try
                {
                    //Make sure there is a map first
                    if (m_memMap == null) return;
    
                    //Create the view stream
                    memStream = m_memMap.CreateViewStream();
                    memStream.Seek(0, SeekOrigin.Begin);
    
                    //Create the object to write to the memory map
                    using (BinaryWriter writer = new BinaryWriter(memStream))
                    {
                        //Convert the structure to a byte array
                        byte[] rawPacket = PacketToBytes(packet);
    
                        //Write the byte array to memory
                        writer.Write(rawPacket);
                    }
                }
                catch (Exception ex)
                {
                    //BIG ERROR, report it
                    System.Diagnostics.Debug.WriteLine("Error " + ex.Message);
                }
            }
        }
    }
