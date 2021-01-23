    var file1Data = File.ReadLines(@"File1.csv")
                        .Skip(1) // Skip header
                        .Select(line => line.Split(';'))
                        .Select(elements => new MyData
                        {
                            Campionato = elements[0],
                            Data = DateTime.ParseExact(elements[1], "MM'.'dd'.'yyyy", CultureInfo.InvariantCulture),
                            Home = elements[2],
                            Away = elements[3],
                            Hsft = Int32.Parse(elements[4]),
                            Asft = Int32.Parse(elements[5]),
                            Hsht = Int32.Parse(elements[6]),
                            Hsht_2 = Int32.Parse(elements[7])
                        });
    var file2Data = File.ReadLines(@"File2.csv")
                        .Skip(1) // Skip header
                        .Select(line => line.Split(';'))
                        .Select(elements => new MyData
                        {
                            Data = DateTime.ParseExact(elements[0], "MM'.'dd'.'yyyy", CultureInfo.InvariantCulture),
                            Home = elements[1],
                            Away = elements[2],
                            Hodd = float.Parse(elements[3]),
                            Aodd = float.Parse(elements[4])
                        });
    var joinedData = file1Data.Join(
                            file2Data,
                            // Key generation should be optimized. Maybe take a look at http://stackoverflow.com/q/263400/1838048
                            myData => myData.Data.GetHashCode() + myData.Home.GetHashCode() + myData.Away.GetHashCode(),
                            myData => myData.Data.GetHashCode() + myData.Home.GetHashCode() + myData.Away.GetHashCode(),
                            (file1, file2) => new MyData
                            {
                                Campionato = file1.Campionato,
                                Data = file1.Data,
                                Home = file1.Home,
                                Away = file1.Away,
                                Hsft = file1.Hsft,
                                Asft = file1.Asft,
                                Hsht = file1.Hsht,
                                Hsht_2 = file1.Hsht_2,
                                Hodd = file2.Hodd,
                                Aodd = file2.Aodd,
                                Unknown = file2.Unknown
                            });
    myDataGridView.DataSource = joinedData.ToList();
