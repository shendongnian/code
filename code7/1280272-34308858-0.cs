    var text = @"((#) This is text
        ((#) This is subtext 
 
            ((#) This is sub-subtext #)
         #)
    #)";
    var chunks = Regex.Matches(text,
                @"(?s)(?=(\(\(#\)(?>(?!\(\(#\)|#\)).|\(\(#\)(?<D>)|#\)(?<-D>))*(?(D)(?!))#\)))")
                   .Cast<Match>().Select(p => p.Groups[1].Value)
                   .ToList();
    for (var i = 0; i < chunks.Count; i++)
         text = text.Replace(chunks[i], string.Format("{0}) {1}", (i+1), 
                             chunks[i].Substring(4, chunks[i].Length-6).Trim()));
            
