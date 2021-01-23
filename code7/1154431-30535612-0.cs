    private void button1_Click(object sender, EventArgs e)
        {
           string somethingLongToPrint = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
           int i = 0;
           string tmp = string.Empty;
           string overrun = string.Empty;
           int len = somethingLongToPrint.Length - 1; // 0-based counting
           while( i < len)
           {
               if (overrun != string.Empty)
               {
                   // to keep the length down to 80 and still account for overrun, i should subtract the length of overrun
                   // If the number of characters left in "somethingLongToPrint" is less than 80, then then
                   int numberOfCharactersRemaining = somethingLongToPrint.Length - i;
                   if (numberOfCharactersRemaining > 80)
                   {
                       tmp = overrun + somethingLongToPrint.Substring(i - overrun.Length, 80);
                   }
                   else
                   {
                       tmp = overrun + somethingLongToPrint.Substring(somethingLongToPrint.Length - numberOfCharactersRemaining);
                   }
               }
               else
               {
                   tmp = somethingLongToPrint.Substring(i, ((80 - overrun.Length)));
               }
               overrun = print80CharacterLine(tmp);
               i += 80;
           }
        }
        // returns what was not printed
        private string print80CharacterLine(string src)
        {
            string eol = "\r\n";
            string whatIsLeft = string.Empty;
            int index = src.LastIndexOf(" ");
            string calculatedString = src.Substring(0, index);
            whatIsLeft = src.Substring((index+1));
            // print statement here
            // do the e.Graphics.DrawString(lines[linesPrinted], someFont, brush, x, y);
            textBox1.Text += calculatedString + eol;
            return whatIsLeft;
        }
