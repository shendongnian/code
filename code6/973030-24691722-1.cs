    for (var processors = 0; processors < 16; processors++)
            {
                var myLineHolder = lineHolders[processors % lineHolders.Length];
                var myChunkHolder = chunksHolder[processors % chunksHolder.Length];
                processorTaskArray[processors] = Task.Factory.StartNew((arg) =>
                {
                    var properArg = (object[]) arg;
                    var lines = (BlockingCollection<string>) properArg[0]; // compiler generates error here
                    var chunks = (BlockingCollection<List<BsonDocument>>) properArg[1]; // compiler generates error here
                    // perform my work...
                },
                new object[]
                  {
                      myLineHolder, 
                      myChunkHolder
                  });
            }
