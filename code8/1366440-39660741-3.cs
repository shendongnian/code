    public class CalculateCIDRProgram
    {
        private static Stopwatch __watch;
        public static void Main()
        {
            __watch = Stopwatch.StartNew();
            Test(IPAddress.Parse("255.255.255.255"));
            Test(IPAddress.Parse("255.255.255.0"));
            Test(IPAddress.Parse("255.255.0.0"));
            Test(IPAddress.Parse("255.0.0.0"));
            Test(IPAddress.Parse("255.255.254.0"));
            Test(IPAddress.Parse("128.0.0.0"));
            Test(IPAddress.Parse("111.111.111.0"));
            Console.ReadLine();
        }
        private static void Test(IPAddress ip)
        {
            WriteHeader(ip);
            var ipbytes = ip.GetAddressBytes();
            var loops = 1000000;
            var cidrnet = null as int?;
            var results = new List<object>();
            __watch.Restart();
            for (int i = 0; i < loops; i++)
                cidrnet = MaskToCIDR_Fancy(ipbytes);
            results.Add(new { __watch.Elapsed, cidrnet, method = nameof(MaskToCIDR_Fancy) });
            __watch.Restart();
            for (int i = 0; i < loops; i++)
                cidrnet = MaskToCIDR_Fast(ipbytes);
            results.Add(new { __watch.Elapsed, cidrnet, method = nameof(MaskToCIDR_Fast) });
            fakeBool = true;
            fakeInt = new Random().Next(33);
            __watch.Restart();
            for (int i = 0; i < loops; i++)
                cidrnet = MaskToCIDR_Constant(ipbytes);
            results.Add(new { __watch.Elapsed, cidrnet, method = nameof(MaskToCIDR_Constant) });
            __watch.Restart();
            for (int i = 0; i < loops; i++)
                cidrnet = MaskToCIDR_Ultra(ipbytes);
            results.Add(new { __watch.Elapsed, cidrnet, method = nameof(MaskToCIDR_Ultra) });
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine();
        }
        private static int fakeInt;
        private static bool fakeBool;
        private static int MaskToCIDR_Ultra(byte[] bytes)
        {
            var b0 = bytes[0];
            var b1 = bytes[1];
            var b2 = bytes[2];
            var b3 = bytes[3];
            return
                (b0 & 0x80) == 0 ? 0 :
                (b0 & 0x40) == 0 ? 1 :
                (b0 & 0x20) == 0 ? 2 :
                (b0 & 0x10) == 0 ? 3 :
                (b0 & 0x08) == 0 ? 4 :
                (b0 & 0x04) == 0 ? 5 :
                (b0 & 0x02) == 0 ? 6 :
                (b0 & 0x01) == 0 ? 7 :
                (b1 & 0x80) == 0 ? 8 :
                (b1 & 0x40) == 0 ? 9 :
                (b1 & 0x20) == 0 ? 10 :
                (b1 & 0x10) == 0 ? 11 :
                (b1 & 0x08) == 0 ? 12 :
                (b1 & 0x04) == 0 ? 13 :
                (b1 & 0x02) == 0 ? 14 :
                (b1 & 0x01) == 0 ? 15 :
                (b2 & 0x80) == 0 ? 16 :
                (b2 & 0x40) == 0 ? 17 :
                (b2 & 0x20) == 0 ? 18 :
                (b2 & 0x10) == 0 ? 19 :
                (b2 & 0x08) == 0 ? 20 :
                (b2 & 0x04) == 0 ? 21 :
                (b2 & 0x02) == 0 ? 22 :
                (b2 & 0x01) == 0 ? 23 :
                (b3 & 0x80) == 0 ? 24 :
                (b3 & 0x40) == 0 ? 25 :
                (b3 & 0x20) == 0 ? 26 :
                (b3 & 0x10) == 0 ? 27 :
                (b3 & 0x08) == 0 ? 28 :
                (b3 & 0x04) == 0 ? 29 :
                (b3 & 0x02) == 0 ? 30 :
                (b3 & 0x01) == 0 ? 31 : 
                32;
        }
        private static int MaskToCIDR_Constant(byte[] bytes)
        {
            int cidrnet = 0;
            var done = false;
            var invalid = false;
            for (var i = 0; i < bytes.Length; i++)
            {
                for (int v = bytes[i], j = 0; j < 8; v = v << 1, j++)
                {
                    if ((v & 0x80) == 0)
                    {
                        fakeBool = done;
                        done = true;
                        if (fakeBool)
                            fakeInt++;
                        else
                            fakeInt++;
                    }
                    else
                    {
                        invalid = done;
                        fakeBool = true;
                        if (done)
                            fakeInt++;
                        else
                            cidrnet++;
                    }
                }
            }
            if (invalid)
                cidrnet = ~cidrnet;
            else
                fakeInt = ~fakeInt;
            return cidrnet;
        }
        private static int MaskToCIDR_Fast(byte[] bytes)
        {
            int cidrnet = 0;
            var zeroed = false;
            for (var i = 0; i < bytes.Length; i++)
            {
                for (int v = bytes[i]; (v & 0xFF) != 0; v = v << 1)
                {
                    if (zeroed)
                        // invalid netmask
                        return ~cidrnet;
                    if ((v & 0x80) == 0)
                        zeroed = true;
                    else
                        cidrnet++;
                }
            }
            return cidrnet;
        }
        private static int MaskToCIDR_Fancy(byte[] bytes)
        {
            return Convert
                   .ToString(BitConverter.ToInt32(bytes, 0), 2)
                   .ToCharArray()
                   .Count(x => x == '1');
        }
        private static void WriteHeader(IPAddress ip)
        {
            var binIp = string.Join(".", ip.GetAddressBytes().Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
            Console.WriteLine($"{binIp} ({ip})");
        }
    }
