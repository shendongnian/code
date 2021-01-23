    int guesssum; //declare this
    .
    .
    if (int.TryParse(txtUserAnswer.Text, out guesssum)) //use guesssum here
    {
        if (guesssum == sum){
            MessageBox.Show("Correct Answer!", "Correct");
            correct++;
        }
        else {
             //wrong, do something!
        }
    }
