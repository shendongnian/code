        string strProductCategories = "Category A|Category A > Sub Category 1|Category B|Category C|Category C > Sub Category 2";
        List<string> firstSplitResults = strProductCategories.SplitAndTrim('|');
        for (int i = 0; i < firstSplitResults.Count; i++)
        {
            int occCount = (strProductCategories.Length - strProductCategories.Replace(firstSplitResults[i], "").Length) / firstSplitResults[i].Length;
            if (occCount > 1)
            {
                firstSplitResults.RemoveAt(i);
                i--;
            }
        }
        
        // print result
        for (int i = 0; i < firstSplitResults.Count; i++)
        {
            Console.WriteLine(firstSplitResults[i]);
        }
        Console.ReadLine();
