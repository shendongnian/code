    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TimeClock
    {
        class Program
        {
            static void Main()
            {
                var blockStart = new TimeSpan(0, 6, 0, 0);
                var blockEnd = new TimeSpan(0, 17, 0, 0);
    
                var listOfTimeLogs = new List<TimeLog>
                {
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,6,0,0),EntryType = EntryTypes.In},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,10,0,0),EntryType = EntryTypes.Out},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,10,15,0),EntryType = EntryTypes.In},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,12,0,0),EntryType = EntryTypes.Out},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,12,30,0),EntryType = EntryTypes.In},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,15,0,0),EntryType = EntryTypes.Out},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,15,15,0),EntryType = EntryTypes.In},
                    new TimeLog {EntryDateTime = new DateTime(2016,05,20,18,00,0),EntryType = EntryTypes.Out}
                };
    
    
                // You are going to have have for / for each unless you use Linq
    
                // fist I would count clock in's versus the out's
                var totalIn = listOfTimeLogs.Count(e => e.EntryType == EntryTypes.In);
                var totalOut = listOfTimeLogs.Count() - totalIn;
    
                // check if we have in the number of time entries
                if (totalIn > totalOut)
                {
                    Console.WriteLine("Employee didn't clock out");
                }
    
                // as I was coding this sample program, i thought of another way to store the time
                // I would store them in blocks - we have to loop
                var timeBlocks = new List<TimeBlock>();
                for (var x = 0; x < listOfTimeLogs.Count; x += 2)
                {
                    // create a new WORKING block based on the in/out time entries
                    timeBlocks.Add(new TimeBlock
                    {
                        BlockType = BlockTypes.Working,
                        In = listOfTimeLogs[x],
                        Out = listOfTimeLogs[x + 1]
                    });
    
                    // create a BREAK block based on gaps
                    // check if the next entry in a clock in
                    var breakOut = x + 2;
                    if (breakOut < listOfTimeLogs.Count)
                    {
                        var breakIn = x + 1;
                        // create a new BREAK block
                        timeBlocks.Add(new TimeBlock
                        {
                            BlockType = BlockTypes.Break,
                            In = listOfTimeLogs[breakIn],
                            Out = listOfTimeLogs[breakOut]
                        });
                    }
                }
    
                var breakCount = 0;
                // here is a loop for displaying detail
                foreach (var block in timeBlocks)
                {
                    var lineTitle = block.BlockType.ToString();
                    // this is me trying to be fancy
                    if (block.BlockType == BlockTypes.Break)
                    {
                        if (block.IsBreak())
                        {
                            lineTitle = $"Break #{++breakCount}";
                        }
                        else
                        {
                            lineTitle = "Lunch";
                        }
                    }
                    Console.WriteLine($" {lineTitle,-10} {block}  ===  Length: {block.Duration.ToString(@"hh\:mm")}");
                }
    
                // calculating total time for each block type
                var workingTime = timeBlocks.Where(b => b.BlockType == BlockTypes.Working)
                        .Aggregate(new TimeSpan(0), (p, v) => p.Add(v.Duration));
    
                var breakTime = timeBlocks.Where(b => b.BlockType == BlockTypes.Break)
                        .Aggregate(new TimeSpan(0), (p, v) => p.Add(v.Duration));
    
    
                Console.WriteLine($"\nTotal Working Hours: {workingTime.ToString(@"hh\:mm")}");
                Console.WriteLine($"   Total Break Time: {breakTime.ToString(@"hh\:mm")}");
    
                Console.ReadLine();
            }
        }
    }
