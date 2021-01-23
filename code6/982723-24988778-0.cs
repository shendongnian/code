     protected void submitAnswerButton_Click(object sender, EventArgs e)
        {
            answerStatus.Visible = true;
    
            int counter = 0;
            int answer = randomNumber1 + randomNumber2;
            if (mathAnswerTextBox.Text == answer.ToString())
            {
                answerStatus.Text = "Correct!";
                randomNumber1 = random.Next(2, 22);
                randomNumber2 = random.Next(2, 222);
                 num1Label.Text = Convert.ToString(randomNumber1);//add this line 
                 num2Label.Text = Convert.ToString(randomNumber2); //and this line
                num1Label.Visible = true;
                num2Label.Visible = true;
            }
