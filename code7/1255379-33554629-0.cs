    public void Button1_Click(object sender, EventArgs e)
    {
        List<int> userNums = new List<int>();
        List<int> lotteryNums = new List<int>();
        userNums.Add(Convert.ToInt32(textbox1.Text));
        userNums.Add(Convert.ToInt32(textbox2.Text));
        userNums.Add(Convert.ToInt32(textbox3.Text));
        
        Random LotteryNum = new Random();
        lotteryNums.Add(LotteryNum.Next(1, 4));
        lotteryNums.Add(LotteryNum.Next(1, 4));
        lotteryNums.Add(LotteryNum.Next(1, 4));
        lotteryNums.Remove(userNums[0]);
        lotteryNums.Remove(userNums[1]);
        lotteryNums.Remove(userNums[2]);
        if (lotteryNums.Count == 3)
            label1.Text = "You didn't get any matches";
        else if (lotteryNums.Count == 2)
            label1.Text = "You made one match!";
        else if (lotteryNums.Count == 1)
            label1.Text = "You made two matches!";
        else if (lotteryNums.Count == 0)
            label1.Text = "You made three matches, jackpot!";
    }
