        var dataBlocks = data.Split('\n');
        foreach (var block in dataBlocks)
        {
            var numbers = block.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numbers.Length; i++)
            {
                double n = double.NaN;
                bool ok = double.TryParse(numbers[i], out n);
                if (ok) chart1.Series[i].Points.AddXY(rt, n);
                else
                {
                    int p = chart1.Series[i].Points.AddXY(rt, 0);
                    chart1.Series[i].Points[p].IsEmpty = true;
                    Console.WriteLine("some error message..");
                }
            }
        }
