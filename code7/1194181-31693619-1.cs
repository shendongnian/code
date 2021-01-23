            List<test> list = new List<test>()
            {
                new test() { id=1, hasParentObject = false, parentId = 0 },
                new test() { id=2, hasParentObject = true, parentId = 1 },
                new test() { id=3, hasParentObject = false, parentId = 0 },
                new test() { id=4, hasParentObject = true, parentId = 3 },
            };
            list.Sort((s1, s2) => s1.parentId > s2.parentId ? 1 : (s1.parentId < s2.parentId ? -1 : 0));            
            foreach (var item in list)
                Console.WriteLine(item.id);            
            Console.ReadKey();
