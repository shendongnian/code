       public void Sum()
        {
            int total = 0;
            for(int i = 0;i < ToysMade.GetLength(0); i++)
            {
                for(int j = 0;j < ToysMade.GetLength(1); j++)
                {
                    total += ToysMade[i, j];
                }
            }
            txtOutput.Text += "\r\nThe sum of products is: " + total.ToString();
        }
