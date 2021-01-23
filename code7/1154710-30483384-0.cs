    //Defining the structure like in your example
    static List<int[]> rootArray = new List<int[]>{
            new int[]{1,5,7,10},
            new int[]{2,4,6,8},
            new int[]{3,6,9,12}
        };
    static void Main(string[] args)
        {
            //Same loop you posted in your OP, only added a .Where after the initial .Select just to get elements with Index == 0
            foreach(var p in rootArray.Select((x,i) => new {Index = i, Value = x}).Where(f => f.Index == 0).Select(x => x.Value))
            {
                //Since this is a List<int[]> your values are int arrays hence you need a loop to display all the values in it.
                foreach(var i in p)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
