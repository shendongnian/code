        private static void Main()
        {
            string myRankValue = "";
            var xml = @"<Database>
                      <Member>
                        <Name>PersonA</Name>
                        <Rank>RankIWant</Rank>
                      </Member>
                      <Member>
                        <Name>PersonB</Name>
                        <Rank>RankIDontWant</Rank>
                      </Member>
                    </Database>";
            var xDoc = XDocument.Parse(xml);
            var firstMember =
                xDoc.Descendants("Member")
                    .Where(d => d.Descendants("Name").First().Value == "PersonA")
                    .Descendants("Rank")
                    .FirstOrDefault();
            if (firstMember != null)
            {
                myRankValue = firstMember.Value;
            }
            Console.WriteLine(myRankValue);
        }
    }
