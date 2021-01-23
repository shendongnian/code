    using System;
    using System.Linq;
    using System.Numerics;
    
    namespace RealNumber
    {
        class RealNum
        {
            private BigInteger m = 0;
            private int w = 0;
    
            private static int divPrecision = 100000;
            private static char[] trimStartChar = { '0', '-' };
            private static char[] trimEndChars = { '.', ',' };
    
            public RealNum()
            {
    
            }
    
            public RealNum(BigInteger _m, int _w = 0 )
            {
                w = _w;
                m = _m;
    
                miniW();
            }
    
            public RealNum(string number)
            {
                number = number.Trim();
    
                System.Text.RegularExpressions.Regex textValidator = new System.Text.RegularExpressions.Regex(@"^-?[0-9]+([,.][0-9]+)?$");
    
                if (!textValidator.IsMatch(number))
                {
                    throw new FormatException();
                }
    
                bool minSig = number.Contains('-');
    
                number = number.TrimStart(trimStartChar);
                if (number.Contains('.') || number.Contains(','))
                {
                    number = number.TrimEnd(trimStartChar);
                    number = number.TrimEnd(trimEndChars);
                }
            
                if (string.IsNullOrEmpty(number))
                {
                    return;
                }
    
                char[] splitChars = { '.', ',' };
    
                string[] idnum = number.Split(splitChars, StringSplitOptions.None);
                if (string.IsNullOrEmpty(idnum[0]))
                    idnum[0] = "0";
    
                if(idnum.Length==1)
                {
                    m = BigInteger.Parse(idnum[0]);
                }
                else
                {
                    w = idnum[1].Length;
                    m = BigInteger.Parse(idnum[0]) * BigInteger.Pow(10, idnum[1].Length) + BigInteger.Parse(idnum[1]);
                }
    
                if (minSig)
                    m = -m;
    
                miniW();
    
            }
    
            private void miniW()
            {
                while( m % (new BigInteger(10)) == 0 && m > 0 )
                {
                    m = m / 10;
                    w--;
                }
            }
    
    
            public override string ToString()
            {
                string num = m.ToString();
    
                if (w > 0)
                {
    
                    if(num.Length - w <= 0)
                    {
                        string zeros = new string('0', -num.Length + w + 1);
                        num = zeros + num;
                    }
    
                    num = num.Insert(num.Length - w, ".");
                }
                else if(w < 0)
                {
                    string zeros = new string('0', -w);
                    num = num + zeros;
                }
    
                return num;
            }
    
    
            public static RealNum operator+ (RealNum a, RealNum b)
            {
    
                int wSub = a.w - b.w;
    
                if(wSub<0)
                {
                    wSub = -wSub;
                    a = System.Threading.Interlocked.Exchange(ref b, a);
                }
    
                return new RealNum(a.m + b.m * BigInteger.Pow(10, wSub), a.w);
    
            }
    
            public static RealNum operator -(RealNum a, RealNum b)
            {
                int wSub = a.w - b.w;
    
                if (wSub < 0)
                {
                    wSub = -wSub;
                    a = System.Threading.Interlocked.Exchange(ref b, a);
                    return new RealNum(b.m * BigInteger.Pow(10, wSub) - a.m, a.w);
                }
    
                return new RealNum(a.m - b.m * BigInteger.Pow(10, wSub), a.w);
    
            }
    
            public static RealNum operator *(RealNum a, RealNum b) => 
                new RealNum(a.m * b.m, a.w+b.w);
    
            public static RealNum operator /(RealNum a, RealNum b)
            {
    
                int precision = RealNum.divPrecision;
                if (precision <= b.w)
                    precision = b.w+10;
                int aSubSup = 0;
                int aSub;
                if (a.w < 0)
                {
                    aSubSup = -a.w;
                    aSub = precision;
                }
                else
                {
                    aSub = precision - a.w;
                }
    
                BigInteger am = a.m * BigInteger.Pow(10, aSubSup) * BigInteger.Pow(10, aSub);
    
                return new RealNum(am/b.m, precision-b.w);
    
            }
    
        }
    }
