    private void btnCheckAnswer_Click(object sender, EventArgs e) {
      string Answer = txtGuess.Text;
    
      Attempts += 1;
    
      if (String.Equals(txtGuess.Text, 
                        country[index], 
                        StringComparison.OrdinalIgnoreCase)) {
        CorrectAnswers += 1;
        MessageBox.Show("Correct!");
      }
      else {
        MessageBox.Show("Incorrect!");
      }
    }
