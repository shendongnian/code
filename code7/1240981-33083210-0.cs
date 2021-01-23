     int LastTokenNumberIssued = 0; //here will be the start value
     private void btnPrintToken_Click(object sender, EventArgs e)
     {
        Queue<int> queueTokens = new Queue<int>();
        lblStatus.Text = "There are " + queueTokens.Count.ToString() +
            " customers before you in the queue";
        int nextTokenNumberTobeIssued = LastTokenNumberIssued + 1;
        LastTokenNumberIssued = nextTokenNumberTobeIssued;
        queueTokens.Enqueue(nextTokenNumberTobeIssued);
        AddTokensToListBox(queueTokens);
    }
    private void AddTokensToListBox(Queue<int> queueTokens)
    {
        listTokens.Items.Clear();
        foreach (int token in queueTokens)
        {
            listTokens.Items.Add(token.ToString());
        }
    }
