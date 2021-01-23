    DocumentClient documentClient = new DocumentClient(
                        "SERVICE_ENDPOINT",
                        "MASTER_KEY",
                        ConnectionPolicy.GetDefault(),
                        ConsistencyLevel.Session);
