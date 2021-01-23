        public string IsChecked  {
           set{
               Console.WriteLine(GetCurrentMemberName()); // prints "IsChecked"
           }
        }
        string GetCurrentMemberName([CallerMemberName] string memberName = "")
        {
             return memberName;
        }
