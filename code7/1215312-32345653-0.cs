    private void button1_Click(object sender, EventArgs e)
    {
        String s1 = "Pippo, pluto. paperino";
        String s2 = "Pippo, PLUTO. paperino";
        String s3 = "PIPPO, PLUTO. PAPERINO";
        MessageBox.Show(myStringConverter(s1));
        MessageBox.Show(myStringConverter(s2));
        MessageBox.Show(myStringConverter(s3));
    }
    public string myStringConverter(string str)
    {
        string[] strArray = str.Split(' '); // Word is always seprate by Space.
        string Answer = "";
        for (int i = 0; i < strArray.Length; i++)
        {
            string tempStr = strArray[i];
            var withoutSpecialCharacter = new string(tempStr.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)).ToArray());
            if (!withoutSpecialCharacter.All(char.IsUpper))
            {
                Answer += strArray[i].ToLower() + " ";
            }
            else
            {
                Answer += strArray[i] + " ";
            }
        }
        return Answer;
    }
