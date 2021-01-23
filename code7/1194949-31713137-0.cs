    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<w:sdt xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>\n" +
                      "<w:sdtPr>\n" +
                        "<w:pPr>\n" +
                          "<w:jc w:val='right'/>\n" +
                        "</w:pPr>\n" +
                        "<w:rPr>\n" +
                          "<w:rFonts w:asciiTheme='minorHAnsi' w:eastAsiaTheme='minorHAnsi' w:hAnsiTheme='minorHAnsi'/>\n" +
                          "<w:bCs w:val='0'/>\n" +
                          "<w:i w:val='0'/>\n" +
                          "<w:color w:val='auto'/>\n";
                //remove spaces at beginning of line
                string pattern1 = @"^\s+<";
                input = Regex.Replace(input, pattern1, "<");
                //remove spaces and return at end of line
                string pattern2 = ">\\s*\n";
                input = Regex.Replace(input, pattern2, ">",RegexOptions.Singleline);
                    
            }
        }
    }
    ​
