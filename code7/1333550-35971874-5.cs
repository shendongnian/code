    foreach (string s in files)
    {
        using (FileStream fs = new FileStream(s,FileMode.Open, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs))
        { 
            byte[] hdr =  br.ReadBytes(8);
            foreach (ImgHeader sig in imgSigs)
            {
                 byte[] testHdr = new byte[sig.Header.Length];
                 Array.Copy(hdr, testHdr, sig.Header.Length);
                //if( CompareBytes(hdr, sig.Header))
                 if (testHdr.SequenceEqual(sig.Header))
                 { 
                    Console.WriteLine("{0} is {1}", s, sig.Name);
                    break;
                 }
            }
        }
    }
