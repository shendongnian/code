    var fsw = new FileStream(classFilePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None,
        64*1024*1024); // use a large buffer
    using (var file = new StreamWriter(fsw)) // use the filestream
    {
        foreach(var line in fileLines) // for( int i = 0;i < fileLines.Length;i++)
        {
            char[] chars = line.ToCharArray();
            int matched = 0;
            int parsePos = -1;
            bool takeClass = true;
            bool found = false;
            bool space = false;
            // parse until space
            while (parsePos<chars.Length && !space )
            {
                parsePos++;
                space = chars[parsePos] == ' '; // end
                // tokens
                if (chars[parsePos] == ' ' ||
                    chars[parsePos] == ',')
                {
                    if (takeClass 
                        && matched == classValue.Length)
                    {
                        found = true;
                        takeClass = false;
                    }
                    else
                    {
                        // reset matching
                        takeClass = true;
                        matched = 0;
                    }
                }
                else
                {
                    if (takeClass 
                        &&  matched < classValue.Length 
                        && chars[parsePos] == classValue[matched])
                    {
                        matched++; // on the next iteration, match next
                    }
                    else
                    {
                        takeClass = false; // no match!
                    }    
                }
            }
                
            chars[parsePos - 1] = '1'; // replace 1 in front of space
            var correction = 1;
            if (parsePos > 1)
            {
                // is classValue before the comma (or before space)
                if (found)
                {
                    chars[parsePos - 2] = '+';
                }
                else
                {
                    chars[parsePos - 2] = '-';
                }
                correction++;
            }
            else
            {
                // is classValue before the comma (or before space)
                if (found)
                {
                    // not enough space in the array, write a single char
                    file.Write('+');
                }
                else
                {
                    file.Write('-');
                }
            }
            file.WriteLine(chars, parsePos - correction, chars.Length - (parsePos - correction));
        }
    }
