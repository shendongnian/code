        public static object DecryptText(string strText, string strPwd)
        {
            string str = string.Empty;
            strPwd = Strings.UCase(strPwd);
            if ((uint)Strings.Len(strPwd) > 0U)
            {
                int num1 = 1;
                int num2 = Strings.Len(strText);
                int Start = num1;
                while (Start <= num2)
                {
                    int num3 = checked(Strings.Asc(Strings.Mid(strText, Start, 1)) - Strings.Asc(Strings.Mid(strPwd, unchecked(Start % Strings.Len(strPwd)) + 1, 1)));
                    str = str + Conversions.ToString(Convert.ToChar(Conversions.ToString(num3) + Conversions.ToString((int)byte.MaxValue)));
                    checked { ++Start; }
                }
            }
            else
                str = strText;
            return (object)str;
        }
