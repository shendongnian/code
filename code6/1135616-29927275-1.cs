        public void PrintNumbersInFile(string fileName)
        {
            File.ReadAllLines(fileName) // reads the lines in the file into a string[]
                .Select(l => double.Parse(l.Trim())) // for each item in the string[], parse the string into a double after trimming any spaces around it
                .OrderBy(n => n) // sort by the value of the double
                .ToList() // put the sorted values in a list
                .ForEach(n => Console.Write("{0}    ", n)); // and for each item in the list, write out its value
        }
