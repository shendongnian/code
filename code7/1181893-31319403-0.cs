    string curKey     =""   ; 
    string keyLength  = ... ; // set totalength of 4 first columns
    string outputLine = ""  ;
    
    private void ProcessInputLine(string line)
    {
      string newKey=line.substring(0,keyLength) ;
      if (newKey==curKey) outputline+=line.substring(keyLength) ;
      else 
      { 
        if (outputline!="") ProcessOutPutLine(outputLine)
        curkey = newKey ;
        outputLine=Line ;
    }
