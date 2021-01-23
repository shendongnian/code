     List<char>     guessWord = new List<char>(25);
            int i = textBox1.TextLength;
    for (int j = 0; j < i; j++)
        {
            if (input == passWord[j])
            {
                guessWord.Insert(j, passWord[j]); //set j index of an array or     list to the corresponding character
            }
                else
        {
                guessWord.Insert(j,' ');  // or you can use an underscore _ to indicate that there should have been a letter there.  You could also add a line here to create a list or array containing wrong guesses and display those
            }
        }
            label1.Text = ""; //clear prior guesses
            foreach(char c in guessWord)
        {
            label1.Text += c;
        }
