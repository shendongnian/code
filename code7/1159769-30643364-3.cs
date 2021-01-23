        public static void GroupTest()
        {
            var testGroup = new List<TestGroup>();
            testGroup.Add(new TestGroup { ColumnA = 16, ColumnB = 651, ColumnC = "a", ColumnD = "European Union" });
            testGroup.Add(new TestGroup { ColumnA = 16, ColumnB = 651, ColumnC = "x", ColumnD = "Membership" });
            testGroup.Add(new TestGroup { ColumnA = 17, ColumnB = 651, ColumnC = "a", ColumnD = "Great Britain" });
            testGroup.Add(new TestGroup { ColumnA = 17, ColumnB = 651, ColumnC = "z", ColumnD = "Economic integration" });
            testGroup.Add(new TestGroup { ColumnA = 18, ColumnB = 651, ColumnC = "a", ColumnD = "European Union countries" });
            testGroup.Add(new TestGroup { ColumnA = 18, ColumnB = 651, ColumnC = "x", ColumnD = "Economic integration" });
            var test = (from x in testGroup
                group x by new {x.ColumnA, x.ColumnB}
                into grp select grp).ToList().Select(grp=> new
                {
                    TagNo = grp.Key.ColumnB,
                    Text = String.Join(" | ", grp.Select(y => y.ColumnC + " " + y.ColumnD))
                });
            foreach (var x in test)
            {
                Console.WriteLine(String.Format("Tag No: {0}\t Text : {1}", x.TagNo, x.Text));
            }
            Console.Read();
        }
