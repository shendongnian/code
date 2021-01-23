        public static void Main( string[] args )
        {
            IntPtr strPtr = IntPtr.Zero;
            string str = "Hello";
            try
            {
                strPtr = Marshal.StringToHGlobalAnsi( str );
                Console.Out.WriteLine( "String: '{0}'; Length: {1}", str, AnsiStrLen( strPtr ) );
            }
            finally
            {
                if( strPtr != IntPtr.Zero )
                {
                    Marshal.FreeHGlobal( strPtr );
                }
            }
        }
        public static int AnsiStrLen( IntPtr strPtr )
        {
            int size = 0;
            while( Marshal.ReadByte( strPtr ) != 0 )
            {
                size++;
                strPtr = IntPtr.Add( strPtr, 1 );
            }
            return size;
        }
