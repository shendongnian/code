            string test = "STACR 2015-HQA1 M1  125    120    5   x 1.5   0";
            var split_string_remove_empty = test.Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse();
            var change = split_string_remove_empty.Take(1)
                                                  .SingleOrDefault();
            var mm2 = split_string_remove_empty.Skip(1)
                                               .Take(1)
                                               .SingleOrDefault();
            var mm3 = split_string_remove_empty.Skip(3)
                                               .Take(1)
                                               .SingleOrDefault();
            var offer = split_string_remove_empty.Skip(4)
                                                 .Take(1)
                                                 .SingleOrDefault();
            var bid = split_string_remove_empty.Skip(5)
                                               .Take(1)
                                               .SingleOrDefault();
            var bonds = string.Join(" ", split_string_remove_empty.Skip(6)
                                                                  .Reverse());
