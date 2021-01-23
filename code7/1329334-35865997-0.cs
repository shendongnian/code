            public static IEnumerable<string> ReadFromBuffer(IntPtr hOutput, short x, short y, short width, short height)
            {
            IntPtr buffer = Marshal.AllocHGlobal(width * height * Marshal.SizeOf(typeof(CHAR_INFO)));
            if (buffer == null)
                throw new OutOfMemoryException();
            try
            {
                COORD coord = new COORD();
                SMALL_RECT rc = new SMALL_RECT();
                rc.Left = x;
                rc.Top = y;
                rc.Right = (short)(x + width - 1);
                rc.Bottom = (short)(y + height - 1);
                COORD size = new COORD();
                size.X = width;
                size.Y = height;
                if (!ReadConsoleOutput(hOutput, buffer, size, coord, ref rc))
                {
                    // 'Not enough storage is available to process this command' may be raised for buffer size > 64K (see ReadConsoleOutput doc.)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                IntPtr ptr = buffer;
                for (int h = 0; h < height; h++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int w = 0; w < width; w++)
                    {
                        CHAR_INFO ci = (CHAR_INFO)Marshal.PtrToStructure(ptr, typeof(CHAR_INFO));
                        char[] chars = Console.OutputEncoding.GetChars(ci.charData);
                        sb.Append(chars[0]);
                        ptr += Marshal.SizeOf(typeof(CHAR_INFO));
                    }
                    yield return sb.ToString();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
...
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = command; 
            //proc.StartInfo.UseShellExecute = false;
            proc.Start();
            Thread.Sleep(1000);
            bool resultFree = ConsoleApi.FreeConsole();
            if (resultFree)
            {
                Debug.WriteLine("FreeConsole: {0}", true);
            }
            else
            {
                Debug.WriteLine("FreeConsole: {0}", false);
            }
            Debug.WriteLine("Process ID: {0}", Convert.ToUInt32(proc.Id));
            bool result = ConsoleApi.AttachConsole( Convert.ToUInt32(proc.Id) );
            Debug.WriteLine("AttachConsole: {0}", result);
            IntPtr _consoleH = ConsoleApi.GetStdHandle(ConsoleApi.STD_OUTPUT_HANDLE);
            ConsoleApi.CONSOLE_SCREEN_BUFFER_INFO _bufferInfo;
            bool getInfo = ConsoleApi.GetConsoleScreenBufferInfo(_consoleH, out _bufferInfo);
            if (getInfo)
            {
                Debug.WriteLine("GetConsoleScreenBufferInfo: {0}x{1}", _bufferInfo.dwSize.X, _bufferInfo.dwSize.Y);
            }
            else
            {
                Debug.WriteLine("GetConsoleScreenBufferInfo: {0}", false);
            }
            short _widthConsole = _bufferInfo.dwSize.X;
            short _heightConsole = _bufferInfo.dwSize.Y;
            IEnumerable<string> rows = ConsoleApi.ReadFromBuffer(_consoleH, 0, 0, _widthConsole,_heightConsole);
            
            foreach (string row in rows)
            {
                Debug.WriteLine(row);
            }
