     static void Main(string[] args)
        {
            V1Connector connector = V1Connector
                .WithInstanceUrl("https://www.MyV1INstance")
                .WithUserAgentHeader("HappyApp", "0.1")
                .WithUsernameAndPassword("login", "pwd")
                .Build();
            IServices services = new Services(connector);
            IAssetType trType = services.Meta.GetAssetType("TeamRoom");
            Query query = new Query(trType);
            IAttributeDefinition teamAttribute = trType.GetAttributeDefinition("Team.Name");
            IAttributeDefinition nameAttribute = trType.GetAttributeDefinition("Name");
            query.Selection.Add(teamAttribute);
            query.Selection.Add(nameAttribute);
            QueryResult result = services.Retrieve(query);
            Asset teamRooms = result.Assets[0];
            foreach (Asset story in result.Assets)
	        {
	            Console.WriteLine(story.Oid.Token);
	            Console.WriteLine(story.GetAttribute(teamAttribute).Value);
	            Console.WriteLine(story.GetAttribute(nameAttribute).Value);
	            Console.WriteLine();
	        }
