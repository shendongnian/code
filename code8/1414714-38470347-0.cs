    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^(.*)\.([^\.]*)$");
    string testString= "Row.3.1.1";
    System.Text.RegularExpressions.GroupCollection groups = regex.Match(testString).Groups;
    System.Console.WriteLine("Code = " + groups[1]);
    System.Console.WriteLine("RValue = " + groups[2]);
