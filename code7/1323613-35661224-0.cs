      private void button1_Click(object sender, EventArgs e)
        {
        int[] sqrNumbers = new int[10];
        String text = "";
        for (int i = 1; i != sqrNumbers.Length; i++)
        {
            sqrNumbers[i] =  i * i;
            text += (sqrNumbers[i]).ToString()+ Environment.NewLine;
        }
        lblSquares.Text = text;
     }
