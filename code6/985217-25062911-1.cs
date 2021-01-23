    //Split the sentence into an array of words
    String sArray[] = input.Split(' ');
    String holder = "";
    StringBuilder sb = new StringBuilder();
    Decimal outD;
    //Foreach word in the sentence, replace the decimal to 'point' 
    //if the word is a decimal, else keep the word as is. Also add space back in.
    Foreach (string s in sArray)
    {
      holder = Regex.Replace(s, "[^.0-9]", "");
      if(Decimal.tryparse(holder, outD))
      {
          sb.Append(s.Replace(".","-point-"));
      }
      else
      {
          sb.Append(s);
      }
      sb.Append(' ');
    }
    
    
