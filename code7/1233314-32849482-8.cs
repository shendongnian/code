    DateTime target = DateTime.Parse(tbDate.Text);
    DateTime today = DateTime.Today;
    DateTime sixMonthsAgo = today.AddMonths(-6);
    if (sixMonthsAgo >= target)
    {
        // Six months ago today was the target date or later
    }
    else
    {
        // ...
    }
