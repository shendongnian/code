    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < words.Length; i++)
    {
       if (words[i].Contains(keywords))
       {
           var word = words[i].Replace(keywords, "<span>" + keywords + "</span>");
           builder.Append(word);
       }
       else
       {
          builder.Append(words[i]);
       }
       builder.Append(" ");
    }
    result = builder.ToString();
