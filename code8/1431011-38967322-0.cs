     var textfilecontent= File.ReadAllLines(pathToFile);
    
       for (int i = 1; i < textfilecontent.Length; i++)
       {
            // splits the values at delimiter ,
            var valPerLine = textfilecontent[i].Split(',');    
            // only works if you have only two numbers per line
            calculate(valPerLine[0], valPerLine[1])
            
        }
        
        private void calculate(double m, double l)
        {
        	// your formulas, m and l should now be inserted as parameter
        }
