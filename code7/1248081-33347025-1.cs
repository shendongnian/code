    public object BytesToStruct(byte[] bytes, Type type)
            {
                //get the size of Message
                int size = Marshal.SizeOf(type);
                
                if (size > bytes.Length)
                {
                    
                    return null;
                }
                //allocate Message object space
                IntPtr structPtr = Marshal.AllocHGlobal(size);
                //copy the byte array to the space
                Marshal.Copy(bytes, 0, structPtr, size);
                //convert byte array to struct Message
                object obj = Marshal.PtrToStructure(structPtr, type);
                //free the space
                Marshal.FreeHGlobal(structPtr);
                //return object
                return obj;
            }
