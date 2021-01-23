        string input = "2cancer＇.pdf";
        char[] chars = input.ToCharArray();
        foreach (var c in chars)
        {
            if (char.IsPunctuation(c) || char.IsSymbol(c) || char.IsControl(c))
            {
                throw new Exception("Control character detected");
            }
        }
