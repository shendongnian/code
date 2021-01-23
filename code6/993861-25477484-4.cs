            static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            long length=0;
            using (var source = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            using (var dest  = new FileStream(args[1], FileMode.CreateNew, FileAccess.Write))
            {
                source.CopyTo(dest);//default buffer size 81920
                length=source.Length;
            };
            var span = (DateTime.Now-dt).TotalSeconds;
            Console.WriteLine(String.Format("Time: {0} seconds; speed: {1} byte/second", span, length/span));
        }
