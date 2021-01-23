     /// <summary>Use this function like string.Split but instead of a character to split on, 
     /// use a maximum line width size. This is similar to a Word Wrap where no words will be split.</summary>
     /// Note if the a word is longer than the maxcharactes it will be trimmed from the start.
     /// <param name="initial">The string to parse.</param>
     /// <param name="MaxCharacters">The maximum size.</param>
     /// <remarks>This function will remove some white space at the end of a line, but allow for a blank line.</remarks>
     /// 
     /// <returns>An array of strings.</returns>
        public static List<string> SplitOn( this string initial, int MaxCharacters )
        {
     
            List<string> lines = new List<string>();
     
            if ( string.IsNullOrEmpty( initial ) == false )
            {
                string targetGroup = "Line";
                string theRegex = string.Format( @"(?<{0}>.{{1,{1}}})(?:\W|$)", targetGroup, MaxCharacters );
     
                MatchCollection matches = Regex.Matches( initial, theRegex, RegexOptions.IgnoreCase
                                                                          | RegexOptions.Multiline
                                                                          | RegexOptions.ExplicitCapture
                                                                          | RegexOptions.CultureInvariant
                                                                          | RegexOptions.Compiled );
                if ( matches != null )
                    if ( matches.Count > 0 )
                        foreach ( Match m in matches )
                            lines.Add( m.Groups[targetGroup].Value );
            }
     
            return lines;
        }
