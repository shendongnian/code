        List<String> queryResultJson = new ArrayList<>();
		DynamoDB dynamoDB = new DynamoDB(dynamoDBClient);
		Table table = dynamoDB.getTable("table_name");
		Index index = table.getIndex("indexname");
		ItemCollection<QueryOutcome> items = null;
		QuerySpec querySpec = new QuerySpec();
		querySpec.withKeyConditionExpression("firstname = :val1")
				.withValueMap(new ValueMap()						
						.withString(":val1", fname));
		items = index.query(querySpec);
		Iterator<Item> itemIterator = items.iterator();
		while (itemIterator.hasNext()) {			
			queryResultJson.add(itemIterator.next().toJSON());
		}
