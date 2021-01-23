    static void Main(string[] args)
        {
            int index;       
            string name = "Jefferey steinberg";
            string lastName;
            index = name.IndexOf(' ');
            lastName = name[index+1].ToString().ToUpper();
            name = name.Remove(index + 1, 1);
            name = name.Insert(index + 1, lastName);
            Console.WriteLine(name);
            Console.ReadLine();
        }
