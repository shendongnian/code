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
            int parsePos = 0;
            bool takeClass = true;
            bool found = true;
            // parse until space
            while (chars[parsePos] != ' ')
            {
                // if we still need to find the class
                if (takeClass && found)
                {
                    // if we have all chars matched
                    if (matched >= classValue.Length)
                    {
                        // we expect a space or a comma
                        if (chars[parsePos] == ' ' || chars[parsePos] == ',')
                        {
                            // found classValue, stop looking
                            takeClass = false;
                        }
                        else
                        {
                            found = false; // no match!
                        }
                    }
                    else
                    {
                        // chars match 
                        if (chars[parsePos] == classValue[matched])
                        {
                            matched++; // on the next iteration, match next
                        }
                        else
                        {
                            found = false; // no match!
                        }
                    }
                }
                parsePos++; // index out of range if no space...
            }
                
            chars[parsePos - 1] = '1'; // replace 1 in front of space
            var corection = 1;
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
                corection++;
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
            file.WriteLine(chars, parsePos - corection, chars.Length - (parsePos - corection));
        }
    }
