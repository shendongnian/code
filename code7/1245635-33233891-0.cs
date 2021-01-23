        private void CommentOverride(string code, string filePath, int lineNumber, string inputFilePath)
        {
            if (!overrideActive)
            {
                WriteLineToFile("    :  ! BEGIN OVERRIDE COMMENT ;", filePath);
                overrideActive = true;
            }
                
            string commentedLine = code.Insert(5, "//");
            WriteLineToFile(commentedLine, filePath);
            string nextLine = GetLine(inputFilePath, lineNumber + 1);
            if ((!nextLine.Contains("WAIT('DI'") && !nextLine.Contains("WAIT('DO'")))
                overrideActive = false;
            if(!overrideActive)
                WriteLineToFile("    :  ! END OVERRIDE COMMENT ;", filePath);
        }
