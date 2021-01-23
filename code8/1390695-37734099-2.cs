        public static KeyPair generate_keys(ParamSet param) {
            uint pub_len = 0;
            uint priv_len = 0;
            IntPtr privkey_blob_len = new IntPtr(priv_len);
            IntPtr pubkey_blob_len = new IntPtr(pub_len);
            IntPtr parameter = Marshal.AllocHGlobal(Marshal.SizeOf(param));
            Marshal.StructureToPtr(param, parameter, false);
            IntPtr pv_ptr = IntPtr.Zero;
            IntPtr pb_ptr = IntPtr.Zero;
            var result = ffi.ffi.pq_gen_key(parameter, out privkey_blob_len, pv_ptr, out pubkey_blob_len, pb_ptr);
            Console.WriteLine("Result: " + result + " Private Key BLob Length: " + privkey_blob_len.ToInt32() + " Public Key Blob Lengh: " + pubkey_blob_len);
           if (result != 0)
              Console.WriteLine("We got problems");
            pv_ptr = Marshal.AllocHGlobal(privkey_blob_len.ToInt32());
            pb_ptr = Marshal.AllocHGlobal(pubkey_blob_len.ToInt32());
            result = ffi.ffi.pq_gen_key(parameter, out privkey_blob_len, pv_ptr, out pubkey_blob_len, pb_ptr);
            if (result != 0)
                Console.WriteLine("We got problems");
           Console.WriteLine("Result: " + result.ToString() + " Private Key BLob Length: " + privkey_blob_len + " Public Key Blob Lengh: " + pubkey_blob_len);
            byte[] privkeyBytes = new byte[privkey_blob_len.ToInt32()];
            byte[] pubkeyBytes = new byte[pubkey_blob_len.ToInt32()];
            Marshal.Copy(pv_ptr, privkeyBytes, 0, privkey_blob_len.ToInt32());
            Marshal.Copy(pb_ptr, pubkeyBytes, 0, pubkey_blob_len.ToInt32());
            Marshal.FreeHGlobal(pv_ptr);
            Marshal.FreeHGlobal(pb_ptr);
            Marshal.FreeHGlobal(parameter);
            return new KeyPair(new PrivateKey(privkeyBytes), new PublicKey(pubkeyBytes));
        }
