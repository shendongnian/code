    var nestedContainer = Container.GetNestedContainer(c =>
                        {
                            var db = MyDbContext.ForShard(shardKey);
                            c.For<MyDbContext>().Use(db);
                        });
    await Next.Invoke(context);
