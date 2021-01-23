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
            var firstMember = xDoc.Descendants("Member").FirstOrDefault();
            if (firstMember != null)
            {
                var myRank = firstMember.Descendants("Rank").FirstOrDefault();
                if (myRank != null)
                {
                    myRankValue = myRank.Value;
                }
            }
            Console.WriteLine(myRankValue);
        }
