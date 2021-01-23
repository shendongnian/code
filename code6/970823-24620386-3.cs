    var fsw = new FileStream(classFilePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None,
        64*1024*1024); // use a large buffer
    using (var file = new StreamWriter(fsw)) // use the filestream
    {
        foreach (var line in fileLines)
        {
            // find the position of space, comma and classValue
            var space = line.IndexOf(' ');
            var comma = line.IndexOf(',', 0, space);
            var classValueIndex = line.IndexOf(classValue,0,space, StringComparison.InvariantCulture);
            // create a char array from line
            char[] chars = line.ToCharArray();
            chars[space - 1] = '1'; // replace 1 in front of space
            var corection = 1;
            if (space > 1)
            {
                // is classValue before the comma (or before space)
                if (classValueIndex < (comma>0?comma:space))
                {
                    chars[space - 2] = '+';
                }
                else
                {
                    chars[space - 2] = '-';
                }
                corection++;
            }
            else
            {
                // is classValue before the comma (or before space)
                if (classValueIndex < (comma > 0 ? comma : space))
                {
                    // not enough space in the array, write a single char
                    file.Write('+');
                }
                else
                {
                    file.Write('-');
                }
            }
            file.WriteLine(chars, space - corection, chars.Length - (space - corection));
        }
