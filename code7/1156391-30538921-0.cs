                var mydata = new[] {
                    new { ID = 1, Field1 = "W", Field2 = "L"},
                    new { ID = 1, Field1 = "A", Field2 = "B"}, 
                    new { ID = 2, Field1 = "A", Field2 = "B"}, 
                    new { ID = 2, Field1 = "C", Field2 = "D"}
                }.ToList();
                var result = mydata.GroupBy(x => x.ID)
                    .Select(x => x.ToList()).ToList();​
