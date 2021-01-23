    public static IEnumerable<string> GetTitleCaseOrdinalNumbers()
    {
        for (int num = 1; num <= int.MaxValue; num++)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    yield return num + "Th";
                    break;
            }
            switch (num % 10)
            {
                case 1:
                    yield return num + "St"; break;
                case 2:
                    yield return num + "Nd"; break;
                case 3:
                    yield return num + "Rd"; break;
                default:
                    yield return num + "Th"; break;
            }
        }
    }
