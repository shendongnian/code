    string str = ">  §> ˜;@  ®>  l? super_test D>ÿÿÿÿ “G? tI> €[> €? È";
    StringBuilder sb = new StringBuilder();
    char? firstLetterOfWord = null;
    foreach (char c in str)
    {
        if ((c >= 'a' && c <= 'z') || c == '_')
        {
            int length = sb.Length;
            if (firstLetterOfWord != null)
            {
                // c is the second character of a word
                sb.Append(firstLetterOfWord);
                sb.Append(c);
                firstLetterOfWord = null;
            }
            else if (length == 0 || sb[length - 1] == ' ')
            {
                // c is the first character of a word; save for next iteration
                firstLetterOfWord = c;
            }
            else
            {
                // c is part of a word; we're not first, and prev != space
                sb.Append(c);
            }
        }
        else if (c == ' ')
        {
            // If you want to eliminate multiple spaces in a row,
            // this is the place to do so
            sb.Append(' ');
            firstLetterOfWord = null;
        }
        else
        {
            firstLetterOfWord = null;
        }
    }
    Console.WriteLine(sb.ToString());
