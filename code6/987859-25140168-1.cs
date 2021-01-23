    var coll = new ObservableCollection<string>() 
            {
                "test1","test2","test3","test4","test5","test6","test7","test8","test9","test10","test11","tes12t","test13","test14","test15"
            };
            var res = coll.TakeSomeIgnoreSome(3,4); // returns 1,2,3,8,9,10,15
