           public string Name
        {
            get { return Name; }
            set
            {
                if (Name.CompareTo("Admin") == 0 || Name.CompareTo("Admin") == -1) //Just trying out comparison with the input.
                {
                    Console.WriteLine("Invalid Name."); //To see if an invalid input that is not "Admin" fails.
                }
                else
                {
                    Name = value; //StackOverFlow here
                    Console.WriteLine("Done.");
                }
            }
        }
