       static void Main(string[] args)
        {
            var p1 = new  Response<Int32>();
            p1.Data = 5;
            var p2 = new Response<string>();
            p2.Data = "Message";
            Console.Out.WriteLine("First: " + JsonConvert.SerializeObject(p1));
            Console.Out.WriteLine("Second: " + JsonConvert.SerializeObject(p2));
        }
