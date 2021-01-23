    static void Main(string[] args)
        {
            //read lines from the text file
            var arr = File.ReadAllLines("dataset.txt").AsQueryable();
            //convert the data to List<object> by convert each line to anonymous object
            var data = arr.Select(line => new { Index = line.Split('.')[0], Value = line.Split('.')[1] });
            //group the data by the value and then select the value and its count
            var res = data.GroupBy(item => item.Value).Select(group => new { Value = group.First().Value, Count = group.Count() });
            //printing result
            Console.WriteLine("Value\t\tCount");
            foreach (var item in res)
            {
                Console.WriteLine("{0}\t\t{1}",item.Value,item.Count);
            }
            Console.ReadLine();
        }
