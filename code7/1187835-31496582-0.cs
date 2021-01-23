    using System.Text.RegularExpressions;
    List<string> l = new List<string>();
            l.Add("CONDITION");
            l.Add("FIRSTCONDITION");
            l.Add("SECONDCONDITION");
            l.Add("ACTION");
           
                foreach (var v in l)
                {
                    int count = Regex.Matches(rtbxTest.Text, v).Count;//count occurrences of string
                    int WordLen = v.Length;
                    int startFrom=0;
                    for (int i = 0; i < count; i++)    
                    {
                        rtbxTest.SelectionStart = rtbxTest.Text.IndexOf(v, startFrom);
                        rtbxTest.SelectionLength = WordLen;
                        rtbxTest.SelectionColor = Color.Red;
                        startFrom = rtbxTest.Text.IndexOf(v, startFrom) + WordLen;
                    }
                }
