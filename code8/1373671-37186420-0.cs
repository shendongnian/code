                //Here you set the config like you want to have it compared
                ComparisonConfig comparisonConfig = new ComparisonConfig()
                {
                    CompareChildren = true,
                    CompareFields = true,
                    CompareReadOnly = true,
                    CompareProperties = true,
                    MaxDifferences = 1,
                    MaxByteArrayDifferences = 1
                };
    
                CompareLogic comparer = new CompareLogic() { Config = comparisonConfig };
    
                list1 = list1.OrderBy(x => x.Id).ToList();
                list2 = list2.OrderBy(x => x.Id).ToList();
    
    
                for (int i =0;i> list1.count;i++)
                {
                    //Here you get a bool if the two Objects are Equal
                    bool areEqual = comparer.Compare(list1[i], list2[i]).AreEqual;
    
                    //Here you get a List of Differences Objects. It contains Values like "expected and "actual" etc.
                    var differences = comparer.Compare(list1[i], list2[i]).Differences;
                   
                    //Here you handle Differences etc.
                }
