    using System.Text.RegularExpressions;
    private static string Compress(string ip)
        {
            var removedExtraZeros = ip.Replace("0000","*");
            //2001:0008:*:CD30:*:*:*:0101
            var blocks = ip.Split(':');
            var regex = new Regex(":0+");
            removedExtraZeros = regex.Replace(removedExtraZeros, ":");
            //2001:8:*:CD30:*:*:*:101
            var regex2 = new Regex(":\\*:\\*(:\\*)+:");
            removedExtraZeros = regex2.Replace(removedExtraZeros, "::");
            //2001:8:*:CD30::101
            return removedExtraZeros.Replace("*", "0");
        }
