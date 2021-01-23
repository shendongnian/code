    public string getColumnString(int columnNumber){
     
        string[] lines = System.IO.ReadAllLines(@"C:\inputfile.txt");
        string stringTobeDisplayed = string.Empty;
        
        foreach(string line in lines) {
            if(columnNumber=-1){ //when column number is sent as -1 then read full line
               stringTobeDisplayed +=  line +"\n"
            }
            else{  //else read only the column required
                string [] words = line.Split();
                stringTobeDisplayed += word[columnNumber] +"\n"
           }
        }
      return stringTobeDisplayed;
    }
    
