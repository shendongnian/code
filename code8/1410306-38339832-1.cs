            if (new[] { "UCK", "SAN", "AVB", "AVM", "SDS", "DWW", "WQP", "LHG" }.Any(s => myString.Contains(s)))
            {
                mySecondString = "CATEGORY A";
            }
            else if (new[] { "UCT", "SAM", "AHJB", "AVR" }.Any(s => myString.Contains(s)))
            {
                mySecondString = "CATEGORY B";
            }
            else if (new[] { "UKC", "SHZ", "EEB" }.Any(s => myString.Contains(s)))
            {
                mySecondString = "CATEGORY C";
            }
            else
            {
                mySecondString = "CATEGORY D";
            }
