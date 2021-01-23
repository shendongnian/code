    public void Button_Click_1(object sender, EventArgs e)
    {
        if(A1.Checked)
        {   
           ReplaceText();
        }
    }
    private void ReplaceText()
    {
        Q1.Text = Q1.Text.Replace("Hello, welcome to the Geography quiz. Press 'A' and then 'Enter' to begin the quiz.", "Question 1: What is the capital of Cuba"); //Changes text to that of the first question
        A1.Text = A1.Text.Replace("A", "Greenwich");
        A2.Text = A2.Text.Replace("B", "Berlin");
        A3.Text = A3.Text.Replace("C", "Bogota");
        A4.Text = A4.Text.Replace("D", "Havana");
    }
