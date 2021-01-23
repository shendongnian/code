    foreach (var item in betSlipwithoutStake)
        {
            test1 = item.Text;
            splitText = test1.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitText.Length == 0)
                continue;
            string stringToCheck = splitText[0];
            int openParenIndex = stringToCheck.IndexOf('(');
            int closeParenIndex = stringToCheck.LastIndexOf(')');
            if (openParenIndex >=0 && closeParenIndex >= 0)
            {
                // get what's inside the outermost set of parens
                int length = closeParenIndex - openParenIndex + 1;
                stringToCheck = stringToCheck.Substring(openParenIndex, length);
            }
            if (!test.Exists(str => str == splitText[0]))
                test.Add(splitText[0]);           
        }
