    var fsw = new FileStream(classFilePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None,
        64*1024*1024);  // use a LARGE buffer
    using (var file = new StreamWriter(fsw)) // instead of classFilePath use the filestream
    {
        foreach (var line in fileLines)
        {
            // check for the position of space and classValue
            var fp = line.IndexOf(' ');
            var cv = line.IndexOf(classValue, StringComparison.InvariantCulture);
            // get a char array
            char[] cb = line.ToCharArray();
            // set the one
            cb[fp - 1] = '1';
            var sa = 1;
            // if we have enough chars in front of the space...
            if (fp > 1)
            {
                // replace two positions in
                // front of the space the + or -
                if (cv < fp)
                {
                    cb[fp - 2] = '+';
                }
                else
                {
                    cb[fp - 2] = '-';
                }
                sa++;
            }
            else
            {
                // to bad, not enoug room, write a single + or -1
                if (cv < fp)
                {
                    file.Write('+');
                }
                else
                {
                    file.Write('-');
                }
            }
            // write the char array from two (or one) pos before the space
            file.WriteLine(cb, fp - sa, cb.Length - (fp - sa));
                          
        }
    }
