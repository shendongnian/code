    var state1 = string.IsNullOrWhiteSpace(textbox1.Text);
    var state2 = string.IsNullOrWhiteSpace(textbox2.Text);
    var state3 = string.IsNullOrWhiteSpace(textbox3.Text);
    if (!(state1 || state2 || state3))
    {
        return "Please Enter a Search Parameter";
    }
    if (!(state1 ^ state2 ^ state3))
    {
        return "Please only enter one Criteria";
    }
    if (state1)
    {
        return "Something else";
    }
    if (state2)
    {
        return "Something there";
    }
    return "Something here";
