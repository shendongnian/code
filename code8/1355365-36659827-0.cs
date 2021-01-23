    using System;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace FontSizeDifference
    {
        static class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            struct ABCFLOAT
            {
                public float abcfA;
                public float abcfB;
                public float abcfC;
            }
            [DllImport("gdi32.dll")]
            static extern bool GetCharABCWidthsFloat(IntPtr hdc, int iFirstChar, int iLastChar, [Out] ABCFLOAT[] lpABCF);
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "SelectObject", SetLastError = true)]
            static extern IntPtr SelectObject(IntPtr hdc, IntPtr obj);
            [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
            static extern bool DeleteObject([In] IntPtr hObject);
            [StructLayout(LayoutKind.Sequential)]
            struct KERNINGPAIR
            {
                public ushort wFirst;
                public ushort wSecond;
                public int iKernAmount;
            }
            [DllImport("gdi32.dll")]
            static extern int GetKerningPairs(IntPtr hdc, int nNumPairs, [Out] KERNINGPAIR[] lpkrnpair);
            [STAThread]
            static void Main()
            {
                var fonts = new[] {
                    new Font("Arial", 7.5f, FontStyle.Regular),
                    new Font("Arial", 8.25f, FontStyle.Regular)
                };
                string textToMeasure = "START";
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hDC = g.GetHdc();
                    foreach (Font font in fonts)
                    {
                        float totalWidth = 0F;
                        IntPtr hFont = font.ToHfont();
                        // Apply the font to dc
                        SelectObject(hDC, hFont);
                        int pairCount = GetKerningPairs(hDC, short.MaxValue, null);
                        var lpkrnpair = new KERNINGPAIR[pairCount];
                        GetKerningPairs(hDC, pairCount, lpkrnpair);
                        Console.WriteLine("\r\n" + font.ToString());
                        for (int ubound = textToMeasure.Length - 1, i = 0; i <= ubound; ++i)
                        {
                            char c = textToMeasure[i];
                            ABCFLOAT characterWidths = GetCharacterWidths(hDC, c);
                            float charWidth = (characterWidths.abcfA + characterWidths.abcfB + characterWidths.abcfC);
                            totalWidth += charWidth;
                            int kerning = 0;
                            if (i < ubound)
                            {
                                kerning = GetKerningBetweenCharacters(lpkrnpair, c, textToMeasure[i + 1]).iKernAmount;
                                totalWidth += kerning;
                            }
                            Console.WriteLine(c + ": " + (charWidth + kerning) + " (" + charWidth + " + " + kerning + ")");
                        }
                        Console.WriteLine("Total width: " + totalWidth);
                        DeleteObject(hFont);
                    }
                    g.ReleaseHdc(hDC);
                }
            }
            static KERNINGPAIR GetKerningBetweenCharacters(KERNINGPAIR[] lpkrnpair, char first, char second)
            {
                return lpkrnpair.Where(x => (x.wFirst == first) && (x.wSecond == second)).FirstOrDefault();
            }
            static ABCFLOAT GetCharacterWidths(IntPtr hDC, char character)
            {
                ABCFLOAT[] values = new ABCFLOAT[1];
                GetCharABCWidthsFloat(hDC, character, character, values);
                return values[0];
            }
        }
    }
