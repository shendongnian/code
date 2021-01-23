    using System.Text.RegularExpressions;
    private string phoneFormating(string unformatedString)
    {
        Regex phone_reg = new Regex(@"^(\d\d\d)(\d\d\d)(\d\d\d\d)$");//you could write it like this too: (@"^(\d){3}(\d){3}(\d){4}$")
        Match m = phone_reg.Match(unformatedString);
        if (m.Success)//ie if your input string is 10 numbers only
        {
            string formatedString = "(" + m.Groups[1].Value + ")-" + m.Groups[2].Value + "-" + m.Groups[3].Value;
                return formatedString;
        }
        else {return string.Empty;}//or anything else.
    }
