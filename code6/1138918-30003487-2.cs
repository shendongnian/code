        [Test]
        public void TestMethod1()
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            
            //Fake data              
            a.Add(1);
            b.Add(2);
            b.Add(2);
            Assert.IsTrue(AreEquals(a,b), GetDifferentElements(a,b));
        }
        private string GetDifferentElements(List<int> a, List<int> b)
        {
            if (AreEquals(a, b))
            {
                return string.Empty;
            }
            if (a.Count != b.Count)
            {
                return "The two lists have a different length";
            }
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    s.Append(i.ToString() + " ");
                }
            }
            return string.Format("Elements at indexes {0} are different", s.ToString());
        }
        private bool AreEquals(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
