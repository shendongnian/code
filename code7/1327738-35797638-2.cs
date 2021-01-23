         static void Main(string[] args)
        {
            AllApartments all = new AllApartments();
            all.Add(new Private(200000000, 5));
            all.Add(new penthouse(125000000, 4));
            all.Add(new penthouse(125000000, 2));
            all.Add(new penthouse(125000000, 7));
            all.Add(new penthouse(125000000, 1));
            int roomN;
            int price;
            int type1;
            type1 = int.Parse(Console.ReadLine());
            //Type type = Type.GetType("ConsoleApplication48.Aapartment");
            roomN = Convert.ToInt32(Console.ReadLine());
            price = Convert.ToInt32(Console.ReadLine());
            Type type;
            switch (type1)
            {
                case 0 :
                    return typeof (penthouse);
                    break;
                case 1:
                    return typeof (Private);
                    break;
                default:
                    throw new Exception("Appartment type unknown");
            }
            Aapartment temp = all.Search(price, roomN, type);
            Console.WriteLine(temp.GetType().ToString());
        }
