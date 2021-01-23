    string a = "09335887170";
    Int64 myInt;
    bool isValid = Int64.TryParse(a, out myInt);
    if (isValid)
    {
        int plusOne = myInt + 1;
        MessageBox.Show(plusOne.ToString());
    }
