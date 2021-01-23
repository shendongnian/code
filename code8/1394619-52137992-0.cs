        public static string ReadUnicodeString(hid_t groupId, string name)
        {
            var datasetId = H5D.open(groupId, name);
            var typeId = H5D.get_type(datasetId);
            if (H5T.is_variable_str(typeId) > 0)
            {
                var spaceId = H5D.get_space(datasetId);
                hid_t count = H5S.get_simple_extent_npoints(spaceId);
                IntPtr[] rdata = new IntPtr[count];
                GCHandle hnd = GCHandle.Alloc(rdata, GCHandleType.Pinned);
                H5D.read(datasetId, typeId, H5S.ALL, H5S.ALL,
                    H5P.DEFAULT, hnd.AddrOfPinnedObject());
                var attrStrings = new List<string>();
                for (int i = 0; i < rdata.Length; ++i)
                {
                    int attrLength = 0;
                    while (Marshal.ReadByte(rdata[i], attrLength) != 0)
                    {
                        ++attrLength;
                    }
                    byte[] buffer = new byte[attrLength];
                    Marshal.Copy(rdata[i], buffer, 0, buffer.Length);
                    string stringPart = Encoding.UTF8.GetString(buffer);
                    attrStrings.Add(stringPart);
                    H5.free_memory(rdata[i]);
                }
                hnd.Free();
                H5S.close(spaceId);
                H5D.close(datasetId);
                return attrStrings[0];
            }
            // Must be a non-variable length string.
            int size = H5T.get_size(typeId).ToInt32();
            IntPtr iPtr = Marshal.AllocHGlobal(size);
            int result = H5D.read(datasetId, typeId, H5S.ALL, H5S.ALL,
                H5P.DEFAULT, iPtr);
            if (result < 0)
            {
                throw new IOException("Failed to read dataset");
            }
            var strDest = new byte[size];
            Marshal.Copy(iPtr, strDest, 0, size);
            Marshal.FreeHGlobal(iPtr);
            H5D.close(datasetId);
            return Encoding.UTF8.GetString(strDest).TrimEnd((Char)0);
        }
    }
