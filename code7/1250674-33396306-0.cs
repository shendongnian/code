    [Test]
        public void ArrayValueInLinq()
        {
            int[] functionId=new int[]{1,2};
            IList<SQLTable> alltopic=new List<SQLTable>
            {
                new SQLTable
                {
                   topic_id=1,
                   topic_name="john"
                },
                new SQLTable
                {
                   topic_id=1,
                   topic_name="john"
                },
                new SQLTable
                {
                   topic_id=2,
                   topic_name="Tomal"
                },
                new SQLTable
                {
                   topic_id=1,
                   topic_name="john"
                }
            };
            var result = (from at in alltopic
                          select new
                          {
                              id = at.topic_id,
                              topicname = at.topic_name
                          }).Where(p=>functionId.Contains(p.id)).Distinct().ToList();
        }
        public class SQLTable
        {
            public int topic_id { get; set; }
            public string topic_name { get; set; }
        }
