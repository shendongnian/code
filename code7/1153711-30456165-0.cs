        class Program
    {
        static void Main(string[] args)//main cant' be async
        {
            //int res = test().Result;//I must put await here
            bool r = ReserveAHolliday().Result; //this will run Synchronously.
            //ReserveAHolliday(); //this option will run aync : you will see "END" printed before the reservation is complete.
            Console.WriteLine("END");
            Console.ReadLine();
        }
        public async static Task<int> test()
        { //why can't I make it just: public int test()??
            //becuase you cannot use await in synchronous methods. 
            int a1, a2, a3, a4;
            a1 = await GetNumber1();
            a2 = await GetNumber1();
            a3 = await GetNumber1();
            a4 = a1 + a2 + a3;
            return a4;
        }
        public static async Task<int> GetNumber1()
        {
            //await Task.Run(() =>
            //    {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("GetNumber1");
                        await Task.Delay(100); // from what I read using Task.Delay is preferred to using  System.Threading.Thread.Sleep(100);
                    }
            //    });
            return 1;
        }
        public async static Task<bool> ReserveAHolliday()
        {
            //bool hotelOK = await ReserveAHotel();//HTTP async request
            //bool flightOK = await ReserveAHotel();////HTTP async request
            var t1 = ReserveAHotel("FirstHotel");
            var t2 = ReserveAHotel("SecondHotel");
            await Task.WhenAll(t1, t2);
            bool result = t1.Result && t1.Result;// hotelOK && flightOK;
            return result;
        }
        public static async Task<bool> ReserveAHotel(string name)
        {
            Console.WriteLine("Reserve A Hotel started for "+ name);
            await Task.Delay(3000);
            if (name == "FirstHotel") 
                await Task.Delay(500); //delaying first hotel on purpose.
            Console.WriteLine("Reserve A Hotel done for " + name);
            return true;
        }
    }
