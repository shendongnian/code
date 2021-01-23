            private int FindOrder(XmlDocument doc, XmlNode node, string tagName)
            {
                var arr = doc.GetElementsByTagName(tagName);
                for (var i = 0; i < arr.Count; i++)
                {
                    if (arr.Item(i) == node) return i + 1;
                }
                return -1;
            }
    
            [TestMethod]
            public void TestMethod1()
            {
    
                var doc = new XmlDocument();
                doc.LoadXml(@"
     <S>
       <NP>
          <N>
          <W> John </W>
          </N>
        <MN>
           <W> Smith </W>
        </MN>
      </NP>
      <VP>
         <V>
           <W>Asked</W>
         </V>
         <NP>
            <N><W>Me</W>
            </N>
          </NP>
        </VP>
      </S>");
    
                var el = doc.SelectNodes("//VP/NP/N/W").Item(0);
                Assert.AreEqual(FindOrder(doc, el, "W"), 4);
            }
