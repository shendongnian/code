            string[] lines = System.IO.File.ReadAllLines(@"yourFolder\yourCsv.csv");
        
            // Display the file contents by using a foreach loop.
            string[] arr;
            foreach (string line in lines)
            {
                 //you get an array with each cell value
                 arr=line.split(";")
                 //do what you want with arr[1] which i suppose is the col you are interested to
            }
