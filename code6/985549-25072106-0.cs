    private void submitAnswer_Click(object sender, RoutedEventArgs e)
        {
          if (answer.ToString() == mathAnswer.Text) 
            {
                answerStatusLabel.Text = "Correct!";
            }
          else 
            {
                answerStatusLabel.Text = "Incorrect!";
            }
        }
