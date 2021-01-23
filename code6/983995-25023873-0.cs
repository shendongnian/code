    private void button1_Click(object sender, EventArgs e)
    {
        i = 0;
        File.Copy("questions.txt", "questionsCopy.txt", true);
        questionDoc = new StreamReader("questionsCopy.txt");
        if (questionDoc.ReadLine() != null)
        {
            fullText = questionDoc.ReadToEnd();
            questionList = fullText.Split('\t');
            for (int j = 0; j < questionList.Length; j++)
            {
                this.label1.Text = questionList[j];
            }
            questionDoc.Close();
        }
        else
            this.label1.Text = "No questions!";
    }
