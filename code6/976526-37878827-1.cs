     NavigationList<string> n = new NavigationList<string>();
                n.Add("A");
                n.Add("B");
                n.Add("C");
                n.Add("D");
                Assert.AreEqual(n.Current, "A");
                Assert.AreEqual(n.MoveNext, "B");
                Assert.AreEqual(n.MovePrevious, "A");
