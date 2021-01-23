    List<int> BingoNumbers = Enumerable.Range(1, 90).ToList();
    private void btn_Number_Click(object sender, EventArgs e)
    {
        int r = BingoNumbers.OrderBy(bn => Guid.NewGuid()).FirstOrDefault();
        BingoNumbers.Remove(r);
        RichTextBox1.Text = BingoNumbers[r].ToString();
        RichTextBox2.Text = BingoNumbers[r].ToString();
    }
