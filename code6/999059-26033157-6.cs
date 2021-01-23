    using System;
    using System.IO;
    using Org.BouncyCastle.Bcpg.OpenPgp;
    class Program
    {
        private const string PGP_OVERFLOW_KEYBODY =
        "mQENBFP2z94BCADKfQT9DGHm4y/VEAYGL7XiUavbv+aE7D2OZ2jCbwnx7BYzQBu8\r\n" +
        "63v5qYe7oH0oBOiw67VaQSjS58fSBAE8vlTkKjvRAscHJNUX9qZrQoRtpMSnrK7N\r\n" +
        "Ca9N2ptvof7ykF1TAgbxDSSnhwysVznYc7mx76BO6Qx8KChqEd0Yp3w2U89YkUqN\r\n" +
        "qdzjB7ZIhj5hDM9f4eyHwsz0uZgyqLKK5VgNj6dHVmOHZt6+RIydRC2lGfocWKM8\r\n" +
        "loPkk6GiSX9sdEm6GXxi7gV/Q3Jr0G099AFg57cWyj1eO6NC8YHLgBHwrB1IkFwi\r\n" +
        "J0x5IHZssy/XleQ1i1izc3ntWiiH24powuAhABEBAAG0H3N5bmFwczMgPHN5bmFw\r\n" +
        "czNAc2FmZS1tYWlsLm5ldD6JATkEEwECACMFAlP2z94CGwMHCwkIBwMCAQYVCAIJ\r\n" +
        "CgsEFgIDAQIeAQIXgAAKCRD944Hz1MHUYP+AB/4roauazFR5lDrJBFB0YoH4VFKM\r\n" +
        "28IJtuy6OThg3cxhqI/N74sZoxtB90QQk4lcshdpwD7CIe9TCKrnhWokIdm4N91m\r\n" +
        "TGDmW7iIeM3kcPp3mj9/7hGOetESuz9JxhBQ0aHAXYk5LdHeDKyRg1KL3JvWrJ27\r\n" +
        "fioDoLLpxxdudSd2nJLhi0hAaHKnkLVl98r37AwxTigGj+J2rN47D+UepJraf8je\r\n" +
        "eZrY/RfwKJVleF1KYPIgduwX3jdiABrI4EsZP/CdbEWTvmmkFFtD4clSMsmqaXPT\r\n" +
        "a3VeaL/saScBPL93tDsjqCddcgW28hsnhzoJ7TM78j2zNcTXZjK8/tNCDnShuQEN\r\n" +
        "BFP2z94BCADmCAMIpOp518ywUlG5Pze5HdpgGiQF26XzwxUt3mPAMXBUQ7vqRMD/\r\n" +
        "zNagPXKthp/p4t0jRoFwFwF+7CqRrxkv2Rrj5OqDD7JqETY5nfRZ0Hvfi4cPkf2g\r\n" +
        "S17SVI4LSFQ/v/sISNNiI3Bo/xvpOeK+Af087j4BEe8vjFuyzf08HCglKoL6WAp8\r\n" +
        "5+Wc2vj+7EbH61YloKKNugq34AyuNh1QYml6LI04b2KR0b/qXTW8UqLvrh4YGaOp\r\n" +
        "k80l7DpBmKgGtXn8JFfU9V3sGCscSnfzDvKjqpmtKXiJFxO2pyPCN5jRKfGMOSyA\r\n" +
        "fZ21NIrBJER/WvuIAls8Tikk+wKRKXrpABEBAAGJAR8EGAECAAkFAlP2z94CGwwA\r\n" +
        "CgkQ/eOB89TB1GDDEAf+OA9hgb3FLbEtcNvkUl9wTtLaxr9nAsBowofNEITH96hV\r\n" +
        "w4i6em9Rjg29/+4JrnDhibuhsFr/F8uKoj+iZGFw2NpXHYI6yS+BLbuVj8jOkYAy\r\n" +
        "Gq34HMNWXuS1Nr4VHOxKbKmmLu8YhdYRk2KF9fPI2Qj376C69W90R/LHByCrcCg7\r\n" +
        "xmqAvO9a8Eac7Rk+Fc+5NKVw9D1rP7MqZGgIQQoh8jLiI2MblvEEahwNxA9AYs8U\r\n" +
        "PpMD0pdo93wxXIYuKc40MF4yFL9LfpPxDnf373dbYQjk3pNThQ5RagIgLNEhRow4\r\n" +
        "5x/1wcO6FMx5a/irQXnJ2o1XYRvznBeCsoyOAYbikA==";
        static void Main(string[] args)
        {
            string parsedKey = ReadKeyDirectly(PGP_OVERFLOW_KEYBODY);
            if (parsedKey != PGP_OVERFLOW_KEYBODY.Replace("\r\n",""))
                Console.WriteLine("Difference!");
            else
                Console.WriteLine("Same!");
        }
        public static string ReadKeyDirectly(string stringKeyData)
        {
            Stream fs = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(stringKeyData));
            fs.Seek(0, SeekOrigin.Begin);
            PgpPublicKeyRingBundle pubRings = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(fs));
            foreach (PgpPublicKeyRing pubRing in pubRings.GetKeyRings())
                return Convert.ToBase64String(pubRing.GetEncoded());
            return null;
        }
    }
