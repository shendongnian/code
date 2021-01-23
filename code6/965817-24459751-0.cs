            var l = new List<dynamic>();
            l.Add(new {dt=DateTime.Now});
            l.Add(DateTime.Now);
            foreach (var o in l)
            {
                Console.WriteLine(o.ToString());
            }
