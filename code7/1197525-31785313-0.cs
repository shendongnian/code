       public class GetArpTable
        {
            // The max number of physical addresses. 
            const int MAXLEN_PHYSADDR = 8;
           // Define the MIB_IPNETROW structure. 
          
            struct MIB_IPNETROW 
            {
                public int dwIndex;
                public int dwPhysAddrLen;
                public byte mac0;
                public byte mac1;
                public byte mac2;
                public byte mac3;
                public byte mac4;
                public byte mac5;
                public byte mac6;
                public byte mac7;
                public int dwAddr;
                public int dwType;
            }
            // Declare the GetIpNetTable function.
            [DllImport("IpHlpApi.dll")]
            [return: MarshalAs(UnmanagedType.U4)]
            static extern int GetIpNetTable(
               IntPtr pIpNetTable,
               [MarshalAs(UnmanagedType.U4)] 
             ref int pdwSize,
               bool bOrder);
            // The insufficient buffer error. 
            const int ERROR_INSUFFICIENT_BUFFER = 122;
            static IntPtr buffer;
            static int result;
            public GetArpTable()
            {
                // The number of bytes needed. 
                int bytesNeeded = 0;
                // The result from the API call. 
                result = GetIpNetTable(IntPtr.Zero, ref bytesNeeded, false);
                // Call the function, expecting an insufficient buffer. 
                if (result != ERROR_INSUFFICIENT_BUFFER)
                {
                    // Throw an exception. 
                    throw new Win32Exception(result);
                }
                // Allocate the memory, do it in a try/finally block, to ensure 
                // that it is released. 
                buffer = IntPtr.Zero;
                // Try/finally. 
                try
                {
                    // Allocate the memory. 
                    buffer = Marshal.AllocCoTaskMem(bytesNeeded);
                    // Make the call again. If it did not succeed, then 
                    // raise an error. 
                    result = GetIpNetTable(buffer, ref bytesNeeded, false);
                    // If the result is not 0 (no error), then throw an exception. 
                    if (result != 0)
                    {
                        // Throw an exception. 
                        throw new Win32Exception(result);
                    }
                }
                finally
                {
                   
                }
              }
            
             public static string ipstr;
             public static string macname;
             public static void GetNames(IP_Code.LocalHost LocalHost)
             {
                // Now we have the buffer, we have to marshal it. We can read 
                // the first 4 bytes to get the length of the buffer. 
                int entries = Marshal.ReadInt32(buffer);
                
      
                // Increment the memory pointer by the size of the int. 
                IntPtr currentBuffer = new IntPtr(buffer.ToInt64() +
                   Marshal.SizeOf(typeof(int)));
                // Allocate an array of entries. 
                MIB_IPNETROW[] table = new MIB_IPNETROW[entries];
                // Cycle through the entries. 
                for (int index = 0; index < entries; index++)
                {
                    // Call PtrToStructure, getting the structure information. 
                    table[index] = (MIB_IPNETROW)Marshal.PtrToStructure(new
                       IntPtr(currentBuffer.ToInt64() + (index *
                       Marshal.SizeOf(typeof(MIB_IPNETROW)))), typeof(MIB_IPNETROW));
                }
                for (int index = 0; index < entries; index++)
                {
                    IPAddress ip = new IPAddress((table[index].dwAddr& 0xFFFFFFFF));
                    Console.Write("IP:" + ip.ToString() + "\t\tMAC:");
                    
                    ipstr = ip.ToString();
                    macname = "MAC:";
                    byte b;
                    b = table[index].mac0;
                    if (b < 0x10)
                    {
                        Console.Write("0");
                        macname = macname + "0";
                    }
                    else
                    {
                        Console.Write("");
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    b = table[index].mac1;
                    if (b < 0x10)
                    {
                        Console.Write("-0");
                        macname = macname + "-0";
                    }
                    else
                    {
                        Console.Write("-");
                        macname = macname + "-";
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    b = table[index].mac2;
                    if (b < 0x10)
                    {
                        Console.Write("-0");
                        macname = macname + "-0";
                    }
                    else
                    {
                        Console.Write("-");
                        macname = macname + "-";
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    b = table[index].mac3;
                    if (b < 0x10)
                    {
                        Console.Write("-0");
                        macname = macname + "-0";
                    }
                    else
                    {
                        Console.Write("-");
                        macname = macname + "-";
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    b = table[index].mac4;
                    if (b < 0x10)
                    {
                        Console.Write("-0");
                        macname = macname + "-0";
                    }
                    else
                    {
                        Console.Write("-");
                        macname = macname + "-";
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    b = table[index].mac5;
                    if (b < 0x10)
                    {
                        Console.Write("-0");
                        macname = macname + "-0";
                    }
                    else
                    {
                        Console.Write("-");
                        macname = macname + "-";
                    }
                    Console.Write(b.ToString("X"));
                    macname = macname + b.ToString("X");
                    Console.WriteLine();
                    //test for device
                    if (table[index].mac0 == 0x00 && 
                        table[index].mac1 == 0x00 && 
                        table[index].mac2 == 0x00)
                    {
                        //if device matches
                    }
                }   
     
             }
             ~GetArpTable()
             {
                 // Release the memory. 
                 Marshal.FreeCoTaskMem(buffer);
             }
        } ​
