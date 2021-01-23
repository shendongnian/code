            var data1 = new List<Data1>
            {
                new Data1 { Name = "A", Date1 = DateTime.Now },
                new Data1 { Name = "B", Date1 = DateTime.Now }
            };
            var data2 = new List<Data2>
            {
                new Data2 { Name = "C", Date3 = DateTime.Now },
                new Data2 { Name = "D", Date3 = DateTime.Now },
            };
            var query = from key in data1.Select(item => item.Name)
                            .Union(data2.Select(item => item.Name))
            join datum1 in data1 on key equals datum1.Name into kd1
            from sub1 in kd1.DefaultIfEmpty()
            join datum2 in data2 on key equals datum2.Name into kd2
            from sub2 in kd2.DefaultIfEmpty()
            select new
            {
                Name = key,
                Date1 = sub1.Date1,
                Date2 = sub1.Date2,
                Date3 = sub2.Date3,
                Date4 = sub2.Date4
            };
