    using Microsoft.IdentityModel.Tokens;   
    using System;   
    using System.IdentityModel.Tokens.Jwt;   
    using System.Security.Claims; 
    using System.Security.Cryptography;   
    using System.Security.Cryptography.X509Certificates;  
    using System.Text;
    namespace ConsoleApplication2
    { 
    private class JWT
    {
    private bool verbose = false;
    public  string GenerateJWT()
    {
        DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        // Provide proper private key
        string privateSecretKey = "OfED+KgbZxtu4e4+JSQWdtSgTnuNixKy1nMVAEww8QL3IN3idcNgbNDSSaV4491Fo3sq2aGSCtYvekzs7JwXJnNAyvDSJjfK/7M8MpxSMnm1vMscBXyiYFXhGC4wqWlYBE828/5DNyw3QZW5EjD7hvDrY5OlYd4smCTa53helNnJz5NT9HQaDbE2sMwIDAQABAoIBAEs63TvT94njrPDP3A/sfCEXg1F2y0D/PjzUhM1aJGcRiOUXnGlYdViGhLnnJoNZTZm9qI1LT0NWcDA5NmBN6gcrk2EApyTt1D1i4AQ66rYoTF9iEC4Wye28v245BYESA6IIelgIxXGsVyllERsbTkaphzibbYfHmvwMxkn135Zfzd/NOXl/O32vYIomzrNEP+tN2WXhhG8c8+iZ8PErBV3CqrYogYy97d2CeQbXcpd5unPiU4TK0nnzeBAXdgeYuJHFC45YHl9UvShRoe6CHR47ceIGp6WMc5BTyyTkZpctuYJTwaChdj/QuRSkTYmn6jFL+MRfYQJ8VVwSVo5DbkECgYEA4/YIMKcwObYcSuHzgkMwH645CRDoy9M98eptAoNLdJBHYz23U5IbGL1+qHDDCPXxKs9ZG7EEqyWezq42eoFoebLA5O6/xrYXoaeIb094dbCF4D932hAkgAaAZkZVsSiWDCjYSV+JoWX4NVBcIL9yyHRhaaPVULTRbPsZQWq9+hMCgYEA48j4RGO7CaVpgUVobYasJnkGSdhkSCd1VwgvHH3vtuk7/JGUBRaZc0WZGcXkAJXnLh7QnDHOzWASdaxVgnuviaDi4CIkmTCfRqPesgDR2Iu35iQsH7P2/o1pzhpXQS/Ct6J7/GwJTqcXCvp4tfZDbFxS8oewzp4RstILj+pDyWECgYByQAbOy5xB8GGxrhjrOl1OI3V2c8EZFqA/NKy5y6/vlbgRpwbQnbNy7NYj+Y/mV80tFYqldEzQsiQrlei78Uu5YruGgZogL3ccj+izUPMgmP4f6+9XnSuN9rQ3jhy4k4zQP1BXRcim2YJSxhnGV+1hReLknTX2IwmrQxXfUW4xfQKBgAHZW8qSVK5bXWPjQFnDQhp92QM4cnfzegxe0KMWkp+VfRsrw1vXNx";
        rsa = DecodeRSAPrivateKey(FromBase64Url(privateSecretKey));
        //convert to csp format
        var bytes = rsa.ExportCspBlob(false);
        var publicKey = Convert.ToBase64String(bytes);
        //
        RsaSecurityKey _signingKey = new RsaSecurityKey(rsa);
        Microsoft.IdentityModel.Tokens.SigningCredentials signingCredentials =
               new Microsoft.IdentityModel.Tokens.SigningCredentials(_signingKey, SecurityAlgorithms.RsaSha256);
        JwtHeader head = new JwtHeader(signingCredentials);
        head.Add("kid", "lzo-firstpublickey");
        string sNewGuid = Guid.NewGuid().ToString("n");
        var claims = new[]
              {
                  new Claim(JwtRegisteredClaimNames.Iss, "s6BhdRkqt3"),
                  new Claim(JwtRegisteredClaimNames.Sub, "s6BhdRkqt3"),
                  new Claim(JwtRegisteredClaimNames.Aud, "https://cis.ncrs/connect/token"),
                  new Claim(JwtRegisteredClaimNames.Jti,  sNewGuid),
                  new Claim(JwtRegisteredClaimNames.Exp, ((Int64)DateTime.Now.AddMinutes(55).Subtract(UnixEpoch).TotalSeconds).ToString(System.Globalization.CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                  new Claim(JwtRegisteredClaimNames.Iat, ((Int64)DateTime.Now.Subtract(UnixEpoch).TotalSeconds).ToString(System.Globalization.CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
              };
        JwtPayload payload = new JwtPayload(claims);
        JwtSecurityToken jwt = new JwtSecurityToken(head, payload);
        jwt.SigningKey = _signingKey;
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
    private static byte[] FromBase64Url(string base64Url)
    {
        string base64 = string.Empty;
        if (!string.IsNullOrEmpty(base64Url))
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            base64 = padded.Replace("_", "/")
                                    .Replace("-", "+");
        }
        return Convert.FromBase64String(base64);
    }
    private RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
    {
        byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;
        // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
        System.IO.MemoryStream mem = new System.IO.MemoryStream(privkey);
        System.IO.BinaryReader binr = new System.IO.BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
        byte bt = 0;
        ushort twobytes = 0;
        int elems = 0;
        try
        {
            twobytes = binr.ReadUInt16();
            if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                binr.ReadByte();        //advance 1 byte
            else if (twobytes == 0x8230)
                binr.ReadInt16();       //advance 2 bytes
            else
                return null;
            twobytes = binr.ReadUInt16();
            if (twobytes != 0x0102) //version number
                return null;
            bt = binr.ReadByte();
            if (bt != 0x00)
                return null;
            //------  all private key components are Integer sequences ----
            elems = GetIntegerSize(binr);
            MODULUS = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            E = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            D = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            P = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            Q = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            DP = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            DQ = binr.ReadBytes(elems);
            elems = GetIntegerSize(binr);
            IQ = binr.ReadBytes(elems);
            Console.WriteLine("showing components ..");
            if (verbose)
            {
                showBytes("\nModulus", MODULUS);
                showBytes("\nExponent", E);
                showBytes("\nD", D);
                showBytes("\nP", P);
                showBytes("\nQ", Q);
                showBytes("\nDP", DP);
                showBytes("\nDQ", DQ);
                showBytes("\nIQ", IQ);
            }
            // ------- create RSACryptoServiceProvider instance and initialize with public key -----
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAParameters RSAparams = new RSAParameters();
            RSAparams.Modulus = MODULUS;
            RSAparams.Exponent = E;
            RSAparams.D = D;
            RSAparams.P = P;
            RSAparams.Q = Q;
            RSAparams.DP = DP;
            RSAparams.DQ = DQ;
            RSAparams.InverseQ = IQ;
            RSA.ImportParameters(RSAparams);
            return RSA;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            binr.Close();
        }
    }
    private void showBytes(String info, byte[] data)
    {
        Console.WriteLine("{0}  [{1} bytes]", info, data.Length);
        for (int i = 1; i <= data.Length; i++)
        {
            Console.Write("{0:X2}  ", data[i - 1]);
            if (i % 16 == 0)
                Console.WriteLine();
        }
        Console.WriteLine("\n\n");
    }
    private int GetIntegerSize(System.IO.BinaryReader binr)
    {
        byte bt = 0;
        byte lowbyte = 0x00;
        byte highbyte = 0x00;
        int count = 0;
        bt = binr.ReadByte();
        if (bt != 0x02)     //expect integer
            return 0;
        bt = binr.ReadByte();
        if (bt == 0x81)
            count = binr.ReadByte();    // data size in next byte
        else
            if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;     // we already have the data size
            }
        while (binr.ReadByte() == 0x00)
        {   //remove high order zeros in data
            count -= 1;
        }
        binr.BaseStream.Seek(-1, System.IO.SeekOrigin.Current);     //last     ReadByte wasn't a removed zero, so back up a byte
        return count;
    }
}
}
