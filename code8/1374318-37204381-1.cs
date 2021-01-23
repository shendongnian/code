    public RandWord(Form f1)
    {
       //get linecount
       int linesGerman = File.ReadAllLines(pathGerman).Length;
       int linesFrance = File.ReadAllLines(pathFrance).Length;
       //check if same linecount
       if (linesGerman == linesFrance)
       {
          //new random int
          Random rnd = new Random();
          int rndLine = rnd.Next(1, File.ReadAllLines(pathGerman).Length);
          //write to Form1's Textbox tbWord
          f1.TextBoxTxt  = rndLine.ToString();
          MessageBox.Show(rndLine.ToString());
       }
    }
