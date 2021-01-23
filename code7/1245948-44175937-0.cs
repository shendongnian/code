        static void GetPasswordDigest()
        {
            //Get nonce
            Random rnd = new Random();
            Byte[] nonce_b = new Byte[16];
            rnd.NextBytes(nonce_b);
            nonce64 = Convert.ToBase64String(nonce_b);
            Console.WriteLine("Nonce: " + nonce64);
            //Get timestamp
            DateTime created = DateTime.Now;
            creationtime = created.ToString("yyyy-MM-ddTHH:mm:ssZ");
            Byte[] creationtime_b = Encoding.ASCII.GetBytes(creationtime);
            Console.WriteLine("Timestamp: " + creationtime);
            //Convert the plain password to bytes
            Byte[] password_b = Encoding.ASCII.GetBytes(ONVIFPassword);
            //Concatenate nonce_b + creationtime_b + password_b
            Byte[] concatenation_b = new byte[nonce_b.Length + creationtime_b.Length + password_b.Length];
            System.Buffer.BlockCopy(nonce_b, 0, concatenation_b, 0, nonce_b.Length);
            System.Buffer.BlockCopy(creationtime_b, 0, concatenation_b, nonce_b.Length, creationtime_b.Length);
            System.Buffer.BlockCopy(password_b, 0, concatenation_b, nonce_b.Length + creationtime_b.Length, password_b.Length);
            //Apply SHA1 on the concatenation
            SHA1 sha = new SHA1CryptoServiceProvider();
            Byte[] pdresult = sha.ComputeHash(concatenation_b);
            passworddigest = Convert.ToBase64String(pdresult);
            Console.WriteLine("Password digest: " + passworddigest);
        } 
