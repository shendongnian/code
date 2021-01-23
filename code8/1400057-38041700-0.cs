    var ns = server.GetStream();
    // keep state of the parser
    bool Ansi = false;
    bool AnsiSub = false;
    bool InFirstNumber = false;
    bool InSecondNumber = false;
    string firstnumber = String.Empty;
    string secondnumber = String.Empty;
    
    if (ns.CanRead)
    {
        // testcase
        // var ms = new MemoryStream(Encoding.ASCII.GetBytes("foo\x1b[123A\x1b[123;456ftest2\x1bKblah\x1b[s"));
        var sr = new StreamReader(ns, Encoding.ASCII);
        while(!sr.EndOfStream)
        {
            var chr = sr.Read();
            switch (chr)
            {
                case 27:
                    // escape char means next chars will be ANSI code
                    Ansi = true;
                    break;
                default:
                    if (Ansi)
                    {
                        // will this be a single ANSI code char or multiple
                        if (!AnsiSub)
                        {
                            switch ((char)chr)
                            {
                                case '[':
                                    // multiple, set state 
                                    AnsiSub = true;
                                    InFirstNumber = true;
                                    InSecondNumber = false;
                                    firstnumber = string.Empty;
                                    secondnumber = string.Empty;
                                    break;
                                default:
                                    // handle this char if needed
                                    // possible is: 78()DMH
                                    Ansi = false;
                                    AnsiSub = false;
                                    break;
                            }
                        }
                        else
                        {
                            var achar = (char)chr;
                            // number checks and capturing
                            if (Char.IsDigit(achar))
                            {
                                // a bit sloppy
                                if (InFirstNumber)
                                {
                                    firstnumber += achar;
                                } 
                                else
                                {
                                    // HACK, refactor later
                                    if (InSecondNumber)
                                    {
                                        secondnumber += achar;
                                    }
                                }
                            }
                            else
                            {
                                if (achar == ';')
                                {
                                    // number sequence break
                                    InSecondNumber = true;
                                    InFirstNumber = false;
                                }
                                else
                                {
                                    // last char of ANSI code
                                    switch (achar)
                                    {
                                        case 'A':
                                            // Cursor Up		<ESC>[{COUNT}A
                                            break;
                                        case 'f':
                                            // Force Cursor Position	<ESC>[{ROW};{COLUMN}f
                                            Console.WriteLine("Force cursor row:{0}, col:{1}", firstnumber, secondnumber);
                                            break;
                                    }
                                    // now we are done, reset state
                                    Ansi = false;
                                    AnsiSub = false;
                                }
                            }
                        }
                    } 
                    else
                    {
                        // plain character
                        sb.Append((Char)chr);
                    }
                    break;
            }
        }
