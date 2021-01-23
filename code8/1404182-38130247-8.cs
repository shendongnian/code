    public Text led1;  // Text, or whatever your digits are
    public Text led2;
    public Text led3;
    public Text led4;
    
    private void FixLEDs()
     {
     string show = pin + "       "; // just add many spaces on the end
     led1.text = show[0].ToString(); // "show[n]" is a char, not a string
     led2.text = show[1].ToString();
     led3.text = show[2].ToString();
     led4.text = show[3].ToString();
     }
