     foreach(var item in listFromBaseClass)
        {
           //print the item from each listFromBaseClass
           // needs to print Name, DateAccess, Group, SessionDuration, Report in one output file.
            if (item is ChildClassA)
            {
                  Console.WriteLine(((ChildClassA)item).Name);
            }
            else if (item is ChildClassB)
            {
                  Console.WriteLine(((ChildClassB)item).Group);
            }
        }
