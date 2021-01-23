        // Create Class that holds the Attributes for you
        // I am using auto properties here
        // if you don't know what a property is pls google it - you need to know that
        class AccountData
        {
            public int firstNumber { get; set; }
            public string firstString { get; set; }
            public string secondString { get; set; }
            public string thirdString { get; set; }
            public string mailAddress { get; set; }
            public int lastNumber { get; set; }
        }
        List<AccountData> Parser(string FileLocationWithName)
        {
            // FileLocationWithName is something like "C:\MyFolder\MyFile.txt"
            // If you want to write a backsplash (\) you need to write \\
            // or you can use a @ bevore the string
            // without @: "C:\\MyFolder\\MyFile.txt"
            // with @: @"C:\MyFolder\MyFile.txt"
            // Create your list
            List<AccountData> resultList = new List<AccountData>();
            // Oben a new FileStream - a StreamReader is good
            using (StreamReader sr = new StreamReader(FileLocationWithName))
            {
                
                // Read the Whole file <=> sr is not at the end of the stream
                while (!sr.EndOfStream)
                {
                    // read a line and split it into the strings
                    string line = sr.ReadLine();
                    var elementsOfLine = line.Split(' ');
                    // create a new object of your accountData class and fill it with the string elements
                    var tempElement = new AccountData();
                    tempElement.firstNumber = int.Parse(elementsOfLine[0]);
                    tempElement.firstString = elementsOfLine[1];
                    tempElement.secondString = elementsOfLine[2];
                    tempElement.thirdString = elementsOfLine[3];
                    tempElement.mailAddress = elementsOfLine[4];
                    tempElement.lastNumber = int.Parse(elementsOfLine[5]);
                    resultList.Add(tempElement);
                }
            }
            // return your list
            return resultList;
        }
