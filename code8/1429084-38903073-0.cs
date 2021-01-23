    var MyString = "<lastModified>2016-08-11 14:12:26.37 UTC</lastModified>";
    MyString = MyString.Substring(14);
    MyString = MyString.Replace("UTC", "");
    MyString = MyString.Substring(0, MyString.Length - 15);
    DateTime MyDateTime = new DateTime();
    DateTime.TryParse(MyString, out MyDateTime);
    
    if (MyDateTime < DateTime.Now.AddDays(-60) && MyDateTime != new DateTime(0001, 1, 1))
    {
        //Do  Your Code
    }
