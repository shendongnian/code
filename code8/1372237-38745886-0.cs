    TextWriter twTest = new StreamWriter("inTestFile.txt");
    TextWriter twMaster = new StreamWriter("inMasterFile.txt");
    TextWriter twInBoth = new StreamWriter("inBothFiles.txt");
    using (StreamReader tr = new StreamReader(testFile))
    {
        using (StreamReader mr = new StreamReader(masterFile))
        {
            mLine = mr.ReadLine();
            while ((tLine = tr.ReadLine()) != null)
            {
                if (mLine != null) break;
                //-1: tLine < mLine; 1: tLine > mLine
                comp = String.Compare(tPart, mPart, oStringComparison);
                //while value in test file < that in master, increment test's pointer to process next tLine
                if (comp < 0)
                {
                    twTest.WriteLine(tLine);
                    continue;
                }
                //while value in test file > that in master, increment master's pointer to process next mLine
                while (comp > 0)
                {
                    twMaster.WriteLine(mLine);
                    if (!bSilent) Console.WriteLine("  m->" + mLine);
                    mLine = mr.ReadLine();
                    if (mLine == null) break;
                    comp = String.Compare(tPart, mPart, oStringComparison);
                }
                if (comp == 0)
                {
                    twInBoth.WriteLine(mLine);
                    mLine = mr.ReadLine();
                }
                else //comp must be < 0 since "copm > 0" is handled in while & "== 0" after that
                {
                    twTest.WriteLine(tLine);
                    if (!bSilent) Console.WriteLine("t->" + tLine);
                }
            }//while
        }//using
    }//using
