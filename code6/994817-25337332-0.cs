    public enum PairOddEnum
    {
        Evens,
        Odds,
        Both
    }
    public void BindControl(PairOddEnum type)
    {
            if (this.textBox1.Text != "")
            {
        List<string> numbersText = this.textBox1.Text.Split(',').ToList<string>();
        var evens = numbersText.Where(t => int.Parse(t) % 2 == 0).Distinct();
        var odds = numbersText.Where(t => int.Parse(t) % 2 == 1).Distinct();
    
        if (type == PairOddEnum.Evens)
        {
            ListBoxEvenNumbers.DataSource = evens.ToList();
        }
        else if (type == PairOddEnum.Odds)
        {
            ListBoxOddNumbers.DataSource = odds.ToList();
        }
        else
        {
            ListBoxEvenNumbers.DataSource = evens.ToList();
            ListBoxOddNumbers.DataSource = odds.ToList();
        }
    
            }
    
    }
    protected void ButtonClassify_Click(object sender, EventArgs e)
    {
    
    
        if (RadioButtonList1.SelectedValue == "Both") 
        {
            BindControl(PairOddEnum.Both);
        }
    
        if (RadioButtonList1.SelectedValue == "Even")
        {
            BindControl(PairOddEnum.Evens);
        }
    
        if (RadioButtonList1.SelectedValue == "Odd")
        {
            BindControl(PairOddEnum.Odds);
        }
    }
