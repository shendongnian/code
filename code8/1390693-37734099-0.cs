    public static KeyPair generate_keys(ParamSet param) {
            uint pub_len = 0;
            uint priv_len = 0;
            IntPtr privkey_blob_len = new IntPtr(priv_len);
            IntPtr pubkey_blob_len = new IntPtr(pub_len);
            IntPtr parameter = Marshal.AllocHGlobal(Marshal.SizeOf(param));
            Marshal.StructureToPtr(param, parameter, false);
            byte[] pv = new byte[priv_len];
            byte[] pb = new byte[pub_len];
            IntPtr pv_ptr = IntPtr.Zero;
            IntPtr pb_ptr = IntPtr.Zero;
           var result = ffi.ffi.pq_gen_key(parameter, out privkey_blob_len, IntPtr.Zero, out pubkey_blob_len, IntPtr.Zero);
           if (result != 0)
              Console.WriteLine("We got problems");
           result = ffi.ffi.pq_gen_key(parameter, out privkey_blob_len, pv_ptr, out pubkey_blob_len, pb_ptr);
            if (result != 0)
                Console.WriteLine("We got problems");
           Console.WriteLine("Result: " + result.ToString() + " Private Key BLob Length: " + privkey_blob_len + " Public Key Blob Lengh: " + pubkey_blob_len);
            byte[] privkeyBytes = new byte[privkey_blob_len.ToInt32()];
            byte[] pubkeyBytes = new byte[pubkey_blob_len.ToInt32()];
            return new KeyPair(new PrivateKey(privkeyBytes), new PublicKey(pubkeyBytes));
        }
