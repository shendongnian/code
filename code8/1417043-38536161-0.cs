    using System;
    using System.Linq;
    using System.Numerics;
    class Program
    {
        static void Main(string[] args)
        {
            //These are the sequential guids you provided.
            Guid[] guids = new[]
            {
                "53cd98f2504a11e682838cdcd43024a7",
                "7178df9d504a11e682838cdcd43024a7",
                "800b5b69504a11e682838cdcd43024a7",
                "9796eb73504a11e682838cdcd43024a7",
                "c14c5778504a11e682838cdcd43024a7",
                "c14c5779504a11e682838cdcd43024a7",
                "d2324e9f504a11e682838cdcd43024a7",
                "d2324ea0504a11e682838cdcd43024a7",
                "da3d4460504a11e682838cdcd43024a7",
                "e149ff28504a11e682838cdcd43024a7",
                "f2309d56504a11e682838cdcd43024a7",
                "f2309d57504a11e682838cdcd43024a7",
                "fa901efd504a11e682838cdcd43024a7",
                "fa901efe504a11e682838cdcd43024a7",
                "036340af504b11e682838cdcd43024a7",
                "11768c0b504b11e682838cdcd43024a7",
                "2f57689d504b11e682838cdcd43024a7"
            }.Select(l => Guid.Parse(l)).ToArray();
    
            //Convert to BigIntegers to get their numeric value from the Guids bytes then sort them.
            BigInteger[] values = guids.Select(l => new BigInteger(l.ToByteArray())).OrderBy(l => l).ToArray();
    
            for (int i = 0; i < guids.Length; i++)
            {
                //Convert back to a guid.
                Guid sortedGuid = new Guid(values[i].ToByteArray());
    
                //Compare the guids. The guids array should be sequential.
                if(!sortedGuid.Equals(guids[i]))
                    throw new Exception("Not sequential!");
            }
    
            Console.WriteLine("All good!");
            Console.ReadKey();
        }
    }
