    using System;
    using System.Text.RegularExpressions;
    static private string getparam(string input, int index)
    {
       <b>string pattern = @"[^\\s\"']+|\"([^\"]*)\"";
       string[] arrparams = Regex.Split(input,pattern);</b>
       if (arrparams.Length <= index) return "";
       return arrparams[index];
    }
