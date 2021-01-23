        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            using (var questionDoc = new StreamReader("questions.txt"))
            {
                if (questionDoc != null && questionDoc.ReadLine() != null)
                {
                    fullText = questionDoc.ReadToEnd();
                    questionList = fullText.Split('\t');
                    for (int j = 0; j < questionList.Length; j++)
                    {
                        this.label1.Text = questionList[j];
                    }
                }
                else
                    this.label1.Text = "No questions!";
            }
        }
