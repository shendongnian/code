    Random rnd1 = new Random();
    int num1 = -1;
    private void guessButton_Click(object sender, EventArgs e)
    {
        if (num1 == -1)
        {            
            num1 = rnd1.Next(1, 10);
        }
        //...
        //assign -1 to num1 after successful guess.
        num1 = -1;
    }
