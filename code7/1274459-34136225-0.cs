            TestClass t = new TestClass("Name1");
            List<TestClass> list1 = new List<TestClass>();
            list1.Add(t);
            List<TestClass> list2 = new List<TestClass>();
            list2 = list1.Select(item => new TestClass(item)).ToList();
            list2[0].name = "Name2";
