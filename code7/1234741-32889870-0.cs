    using StackExchange.Redis;
    ...
    ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
    IDatabase db = redis.GetDatabase();
    string value = "abcdefg";
    db.StringSet("mykey", value);
    ...
    string value = db.StringGet("mykey");
    Console.WriteLine(value); // writes: "abcdefg"
