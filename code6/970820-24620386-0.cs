    var fsw = new FileStream(classFilePath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None,
        64*1024*1024);
    using (var file = new StreamWriter(fsw)) // classFilePath))
    {
        foreach (var line in fileLines)
        {
            // check for the position of space and classValue
            var fp = line.IndexOf(' ');
            var cv = line.IndexOf(classValue, StringComparison.InvariantCulture);
            // get a char array
            char[] cb = line.ToCharArray();
            // se
            cb[fp - 1] = '1';
            var sa = 1;
            if (fp > 1)
            {
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
                if (cv < fp)
                {
                    file.Write('+');
                }
                else
                {
                    file.Write('-');
                }
            }
            file.WriteLine(cb, fp - sa, cb.Length - (fp - sa));
            //var lineFirstPart = splittedLine.First();
            //string newFirstPart = "-1";
            //if (lineFirstPart.Contains(classValue))
            //{
            //    newFirstPart = "+1";
            //}
            //file.WriteLine("{0} {1}", newFirstPart, splittedLine.Last());
                           
        }
    }
