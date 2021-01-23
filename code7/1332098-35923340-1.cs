       private void PopulateSplits()
        {
            //sets the count
            i_splitCount = 0;
            //reads the split file
            using(StreamReader sr_splits = new StreamReader(@"a\file\path\here\.txt"))
            {
              //begin populating the array
              while (sr_splits.ReadLine() != null)
              {
                  //split ID
                  string split = sr_splits.ReadLine();
                  as_splitNumbers.Add(split);
                  i_splitCount = i_splitCount + 1;
              }
            }
        }
