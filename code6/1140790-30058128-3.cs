    var s1 = Stopwatch.StartNew();
            var a1 = Enumerable.Repeat(new LinkEntity { A = 10 }, 10000).ToList();
            for (int i = 0; i < 10000; i++)
            {
                var b1 = ConvertList<LinkEntity, Link>(a1);
            }
         
            Console.WriteLine(s1.ElapsedMilliseconds);
            var s2 = Stopwatch.StartNew();
            var a2 = Enumerable.Repeat(new LinkEntity { A = 10 }, 10000).ToList();
            for (int i = 0; i < 10000; i++)
            {
                var b2 = ConvertList1(a2);
            }
                
            Console.WriteLine(s2.ElapsedMilliseconds);
            var s3 = Stopwatch.StartNew();
            var a3 = Enumerable.Repeat(new LinkEntity { A = 10 }, 10000).ToList();
            for (int i = 0; i < 10000; i++)
            {
                var b3 = ConvertList3(a3, f => f);
            }
            Console.WriteLine(s3.ElapsedMilliseconds);
