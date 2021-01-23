    string text = "5.0"; // or 5.0 or .75 or 23 or ..
    string err = "input is not a number!";
    if (string.IsNullOrWhiteSpace(text))
    {
	MessageBox.Show(err);
	return;
    }
    Double d;
    // using CultureInfo.InvariantCulture - assuming that decimal point will always be "."
    if (!Double.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out d))
    {
	MessageBox.Show(err);
	return;
    }
    // at this point there is a "d" variable 100% a number, do whatever you want with it
    // AND BTW 5.0/1 = 5.0, not 0 !!
    MessageBox.Show(d.ToString());
    var c = d / 1; //WHY is this there? Every number (even negative number) divide by 1 is the same  number, not matter if it is 4 or 100565.432345 or googol ;)
    string myString = String.Empty;
    if (c == 0.75)
	myString = c.ToString();
    else if (c == .25)
	myString = c.ToString();
    else if (c == .5)
	myString = c.ToString();
    // etc, etc.. don't know your use case
