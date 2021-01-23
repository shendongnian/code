    public static int CompareStrings(string s1, string s2)
    {
        int Customertype1 = Int32.Parse(s1.Substring(0,2));
        int Customertype2 = Int32.Parse(s2.Substring(0,2));
        string check1 = GroupID.GetByIndex(GroupID.IndexOfKey(Customertype1)).ToString();
        string check2 = GroupID.GetByIndex(GroupID.IndexOfKey(Customertype2)).ToString();
 
        if (Customertype1 > Customertype2)
            return 1;
        if (Customertype1 < Customertype2)
            return -1;
        else
        {
            var ReplaceHyp1 = s1.Replace("-", "");
            switch (check1) { 
                case("White"):
                    longFormat1 = ReplaceHyp1.Substring(0,6)+pad.PadLeft((14 -ReplaceHyp1.Length),'0')+ReplaceHyp1.Substring(6,(ReplaceHyp1.Length-6));
                    break;
                case("Blue"):
                    longFormat1 = ReplaceHyp1.Substring(0,7)+pad.PadLeft((14 -ReplaceHyp1.Length),'0')+ReplaceHyp1.Substring(7,(ReplaceHyp1.Length-7));
                    break;
            }
            var ReplaceHyp2 = s2.Replace("-", "");
            switch (check2) { 
                case("White"):
                    longFormat2 = ReplaceHyp2.Substring(0,6)+pad.PadLeft((14 -ReplaceHyp2.Length),'0')+ReplaceHyp2.Substring(6,(ReplaceHyp2.Length-6));
                    break;
                case("Blue"):
                    longFormat2 = ReplaceHyp2.Substring(0,7)+pad.PadLeft((14 -ReplaceHyp2.Length),'0')+ReplaceHyp2.Substring(7,(ReplaceHyp2.Length-7));
                    break;
            }
            return stringCompare(longFormat1, longFormat2);
        }
    }
