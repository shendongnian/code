       static void Main(string[] args) {
            var p1 = new Response<Int32>(5);
            var p2 = new Response<string>("Message");
            JObject p3 = new Response<double>(0.0);
            var p4 = (JObject) new Response<DateTime>(DateTime.Now);
            Console.Out.WriteLine(p1.Serialize());
            Console.Out.WriteLine(p2.Serialize());
            Console.Out.WriteLine(JsonConvert.SerializeObject(p3));
            Console.Out.WriteLine(JsonConvert.SerializeObject(p4));
        }
