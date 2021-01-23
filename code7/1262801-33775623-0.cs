    private const string optionParameterName = "myOption";
    private const string optionText =
      "Text do describe the option, but that should be splitted to several lines if too big.Text should automatically align by a fixed offset.";
    private const int TOTAL_NUMBER_CHARS_PER_LINE = 60;
    public void DisplayHelpEx()
    {
      var offset = optionParameterName.Length + 6;
      Console.WriteLine("The following options are possible:");
      WriteOffset(offset, optionParameterName + ": ", optionText);
    }
    public void WriteOffset(int offset, string label, string text)
    {
      var numChars = TOTAL_NUMBER_CHARS_PER_LINE - offset;
      string offsetString = new string(' ', offset);
      string line;
      bool firstLine = true;
      while ((line = new String(text.Take(numChars).ToArray())).Any())
      {
        if (firstLine)
        {
          Console.Write(label.PadRight(offset));
        }
        else
        {
          Console.Write(offsetString);
        }
        firstLine = false;
        Console.Write(line);
        Console.WriteLine();
        text = new String(text.Skip(numChars).ToArray());
      }
    }
    // output:
    // The following options are possible:
    // myOption:     Text do describe the option, but that should b
    //               e splitted to several lines if too big.Text sh
    //               ould automatically align by a fixed offset.
