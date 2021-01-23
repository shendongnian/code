    foreach (var item in betSlipwithoutStake)
        {
            test1 = item.Text;
            splitText = test1.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (!test.Exists(str => str == splitText[0]))
                test.Add(splitText[0].Split('(', ')')[1]);           
        }
