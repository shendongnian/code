    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace LineOfCounter
    {
        class FileDialtion
        {
            private string FilePath;    // file path
            private string fileName;    //file name
            private long fileSize;      // file size
            private string extension;   // extension
            private bool readOnly;      // is file raad only
            private string creationTime;// file cration time    
            private string accessTime;  // last access time
            private long fileLOC;       // line of code insert in the file
            private int numOfFuncs;     // number of functions in thefile
            private int numOfVariables; // number of variables in the code
            private int numOfLV;        // number of local varibles
            private int numOfGV;        // number of globle variables
            private int numOfComments;  // number of Comments
            private int NumOfPPR = 0;// number of pre proccesssive derectories    
            private bool IsInMultipleComment = false;   // when starts multiple comment ignore Count
            #region getters
            public int getNumberOfPPR
            {
                get { return NumOfPPR; }
            }
            public int getNumOfVariables
            {
                get { return numOfVariables; }
            }
            public int getNumOfGlobleVariables
            {
                get { return numOfGV; }
            }
            public int getNumOfLocalVariables
            {
                get { return numOfLV; }
            }
            public int getNumberOfFunctions
            {
                get { return numOfFuncs; }
            }
            public int getNumberOfComment
            {
                get { return numOfComments; }
            }
            public string getFilePath
            {
                get
                {
                    return FilePath;
                }
            }
            public string getFileName
            {
                get
                {
                    return fileName;
                }
            }
            public string getFileSize
            {
                get
                {
                    return fileSize.ToString();
                }
            }
            public string getFileExtension
            {
                get
                {
                    return extension;
                }
            }
            public string getFileCreationtime
            {
                get
                {
                    return creationTime;
                }
            }
            public string getFileAccessTime
            {
                get
                {
                    return accessTime;
                }
            }
            public long getFileLOC
            {
                get
                {
                    return fileLOC;
                }
            }
    #endregion
            // class Constructor
            public FileDialtion(string filename) {
                try
                {
                    FilePath = filename;
                    FileInfo fi = new FileInfo(getFilePath);
                    fileName = fi.Name;
                    fileSize = fi.Length;
                    extension = fi.Extension;
                    readOnly = fi.IsReadOnly;
                    creationTime = fi.CreationTime.ToString();
                    accessTime = fi.LastAccessTime.ToString();
                    fileLOC = getLOC(fi);   // read loc
                    numOfComments = getNumberOfComments(fi); // get comments
                    NumOfPPR = getNumberOfPPRs(fi);         // get pre processive directories
                    numOfFuncs=getNumberOFFuncions(fi); // read functions
                    numOfVariables = getNumberOfVariables(fi); // get number of variables
                    numOfGV = getNumberOfGlobleVaariables(fi);   // getnumber of LocalVariables
                    numOfLV = numOfVariables - numOfGV;
                }
                catch (Exception es)
                {
                    Console.WriteLine(es.Message);
                }
            }
        #region main get Functuens
            private int getLOC(FileInfo fs) {
                StreamReader rdr;
                int count=0;
                rdr = fs.OpenText();
                while (rdr.ReadLine() != null)
                {
                    count++;
                }
                return count;
            }
            private int getNumberOFFuncions(FileInfo fs) {
                StreamReader rdr;
                int count = 0;
                string tempStr;
                // initialize
                rdr = fs.OpenText();
                tempStr = rdr.ReadLine();
                while (true)
                {
                    if (tempStr == null)
                        break;
                    if(IsFunction(tempStr))
                        count++;
                    tempStr = rdr.ReadLine();
                }
                return count;
            }
            private int getNumberOfVariables(FileInfo fs)
            {
                StreamReader rdr;
                int count = 0;
                string tempStr;
                // initialize
                rdr = fs.OpenText();
                tempStr = rdr.ReadLine();
                while (true)
                {
                    if (tempStr == null)
                        break;
                    count += getVariblesOfLine(tempStr);
                    tempStr = rdr.ReadLine();
                }
                return count;
            }
            private int getNumberOfComments(FileInfo fs)
            {
                StreamReader rdr;
                int count = 0;
                string tempStr;
                // initialize
                rdr = fs.OpenText();
                tempStr = rdr.ReadLine();
                while (true)
                {
                    if (tempStr == null)
                        break;
                    if (IsComment(tempStr))
                        count++;
                    tempStr = rdr.ReadLine();
                }
                return count;
            }
            private int getNumberOfPPRs(FileInfo fs)
            {
                StreamReader rdr;
                int count = 0;
                string tempStr;
                // initialize
                rdr = fs.OpenText();
                tempStr = rdr.ReadLine();
                while (true)
                {
                    if (tempStr == null)
                        break;
                    if (isPPR(tempStr))
                        count++;
                    tempStr = rdr.ReadLine();
                }
                return count;
            }
            private int getNumberOfGlobleVaariables(FileInfo fs)
            {
                StreamReader rdr;
                int count = 0;
                string tempStr;
                // initialize
                rdr = fs.OpenText();
                tempStr = rdr.ReadLine();
                while (true)
                {
                    if (tempStr == null)
                        break;
                    count += getVariblesOfLine(tempStr); // count variables
                    if (tempStr.Contains("main"))       // main function founds
                        break;
                    tempStr = rdr.ReadLine();
                }
                return count;
            }
    #endregion
    #region Supportive Functions
            private bool IsFunction(string line)
            {
                if (line.Contains("//"))
                    return false;
                if (line.Contains("/*"))
                    IsInMultipleComment = true;
                if (line.Contains("*/"))
                    IsInMultipleComment = false ;
                if (!IsInMultipleComment)
                {
                    if (line.Contains("void") || line.Contains("int") || line.Contains("short") || line.Contains("long") || line.Contains("float") || line.Contains("char") || line.Contains("double"))
                    {
                        if (!line.Contains(";"))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            private bool isPPR(string line)
            {
                if (line.Contains("//"))
                    return false;
                if (line.Contains("/*"))
                    IsInMultipleComment = true;
                if (line.Contains("*/"))
                    IsInMultipleComment = false;
                if (!IsInMultipleComment)
                {
                    if (line.Contains("#"))
                    {
                        return true;
                    }
                }
                return false;
            }
            private bool IsComment(string sp)
            {
                if (sp.Contains("//"))
                {
                    return true;
                }
                if (sp.Contains("/*"))
                {
                    return true;
                }
                return false;
            }
            private int  getVariblesOfLine(string line)
            {
                line = line.Trim();  // trim the lines
                if (line.Contains("#"))     // remove preprocessive declarations
                    return 0;
                if (line.Contains("//"))
                    return 0;
                if (line.Contains("/*"))
                    IsInMultipleComment = true;
                if (line.Contains("*/"))
                    IsInMultipleComment = false;
                if (!IsInMultipleComment)
                {
                    if (line.Contains("unsigned") || line.Contains("signed") || line.Contains("int") || line.Contains("short") || line.Contains("long") || line.Contains("float") || line.Contains("char") || line.Contains("double"))
                    {
                        if (!line.Contains("("))    // remove if this is function
                        {
                            Console.WriteLine(line);
                            if (line.Contains(","))     // count at multiple declarations
                            {
                                int y = line.Count(f => f == ',');
                                return y + 1;
                            }
                            return 1;
                        }
                    }
                }
                return 0;
            }
        
    #endregion
        }
    }
