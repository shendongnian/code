            string[] arr = new string[]
        {
            "B $15",
            "A $251",
            "B $5",
            "B $25",
            "A $250",
            "A $45"
        };
            var arrSplited = arr.Select(i => i.Split(' '));
            var letters = arrSplited
                .Select(i => i[0])
                .OrderBy(i => i)
                .ToArray();
            var numbers = arrSplited
                .Select(i => i[1])
                .OrderBy(i => Convert.ToInt32(i.Replace("$", "").Trim()))
                .Select(i => i.ToString())
                .ToArray();
            var result = new List<string>();
            for (int i = 0; i < letters.Length; i++)
            {
                result.Add(letters[i]);
                result.Add(numbers[i]);
            }
