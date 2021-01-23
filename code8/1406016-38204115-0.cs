    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string userInput = textBox1.Text;            //get string from textbox
        if(string.IsNullOrEmpty(userInput)) return;  //return if string is empty
        char c = char.ToUpper(userInput[userInput.Length - 1]); //get last char of string and normalize it to big letter
        int alPos = c-'A'+1;                         //subtract from char first alphabet letter
        label1 = alPos.ToString();                   //print/show letter position in alphabet
    }
