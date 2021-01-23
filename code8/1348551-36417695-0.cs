        void compareAnswers()
        {
            string path = "C:\\DriverTest\\correctAnswers.txt";
            string path2 = "C:\\DriverTest\\userAnswers.txt";
            string[] correctAnswers = System.IO.File.ReadAllLines(@path);
            string[] userAnswers = System.IO.File.ReadAllLines(@path2);
            for (int i = 0; i != 20; i++)
            {
                if (correctAnswers[i] == userAnswers[i])
                {
                    MessageBox.Show("Answer " + (i+1) + " is correct");
                    //Where this will be what I use to implement the scoring system
                }
            }
        }
