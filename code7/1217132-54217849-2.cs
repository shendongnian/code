                TESTAbstract test1 = new TEST1(1001);
                TESTAbstract test2 = new TEST2(1002);
                TESTAbstract test3 = new TEST2(1003);
                TESTAbstract test4 = new TEST1(1004);
                TESTAbstract test5 = new TEST1(1005);
                TESTAbstract test6 = new TEST1(1006);
                TESTAbstract test7 = new TEST2(1007);
                TESTAbstract test8 = new TEST1(1008);
                Console.WriteLine("All StructureItem Elements: " + TESTAbstract.Elements.Count);
                foreach (var item in TESTAbstract.Elements)
                {
                    Console.WriteLine("someValue: " + item.someValue + " localId: " + item.localId + " globalId: " + item.globalId);
                }
                Console.WriteLine("TEST1 Elements: " + TEST1.Elements.Count);
                foreach (var item in TEST1.Elements)
                {
                    Console.WriteLine("someValue: " + item.someValue + " localId: " + item.localId + " globalId: " + item.globalId);
                }
                Console.WriteLine("TEST2 Elements: " + TEST2.Count);
                foreach (var item in TEST2.Elements)
                {
                    Console.WriteLine("someValue: " + item.someValue + " localId: " + item.localId + " globalId: " + item.globalId);
                }
