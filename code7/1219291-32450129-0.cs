       private static void commaSeperate(List<classname> obj)
        {
            string delimeter = ",";
            Console.WriteLine(obj.Aggregate((i, j) => new classname { Name = (i.Name + delimeter + j.Name) }).Name);
            Console.ReadKey();
        }
