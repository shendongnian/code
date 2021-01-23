    struct Record
    {
        public string Name, Surname;
        public int Identity, School;
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\OgrenciBilgisi_v2.txt";
            var position = 0;
            var record = new Record();
            var records = new Dictionary<string, Record>(); // key is the concatenation of name and surname
                
            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                if (line == "---") // TODO use your record delimiter here
                {
                    // start of new record. compare the existing one and commit it if all fields have been written to
                    if (position == 9)
                    {
                        // compare records
                        var key = record.Name + record.Surname;
                        if (records.ContainsKey(key))
                        {
                            // this is a duplicate student name. confirm that the id and school # are different
                            if (records[key].Identity == record.Identity &&
                                records[key].School == record.School)
                            {
                                // id and school are the same, so this is an entirely duplicate record
                            }
                            else
                            {
                                // id and school are different, but name and surname are the same
                                // TODO: show all records
                                return;
                            }
                        }
                        else
                        {
                            records.Add(key, record);
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("Not all fields in record. Malformed data.");
                    }
                     
                    position = 0;
                    record = new Record();
                }
                else
                {
                    switch (position)
                    {
                        case 0:
                            record.Name = line;
                            break;
                        case 1:
                            record.Surname = line;
                            break;
                        case 3:
                            int id;
                            if (int.TryParse(line, out id))
                            {
                                record.Identity = id;
                            } // else there's an error
                            break;
                        case 4:
                            int school;
                            if (int.TryParse(line, out school))
                            {
                                record.School = school;
                            } // else there's an error
                            break;
                    }
                    position++;
                }
            }
        }
    }
