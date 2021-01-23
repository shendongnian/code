            string recordItem = "1234|11-4-2015|John Doe";
            string[] items = recordItem.Split('|');
            int id = 0;
            if (!int.TryParse(items[0], out id))
                throw new InvalidOperationException();
            DateTime startDate = DateTime.MinValue;
            if (!DateTime.TryParse(items[1], out startDate))
                throw new InvalidOperationException();
            //This one shouldn't need validation since it's already a string and 
            //will probably be taken as-is
            string name = items[2];
