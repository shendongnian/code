        private static byte[] derEncodeSignature(byte[] signature)
        {
            byte[] r = signature.RangeSubset(0, (signature.Length / 2));
            byte[] s = signature.RangeSubset((signature.Length / 2), (signature.Length / 2));
            MemoryStream stream = new MemoryStream();
            DerOutputStream der = new DerOutputStream(stream);
            Asn1EncodableVector v = new Asn1EncodableVector();
            v.Add(new DerInteger(new BigInteger(1, r)));
            v.Add(new DerInteger(new BigInteger(1, s)));
            der.WriteObject(new DerSequence(v));
            return stream.ToArray();
        }
