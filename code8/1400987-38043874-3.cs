    public interface IConditionalSerialization
    {
        bool ShouldSerialize();
    }
    public class ConditionalSerializationObject : IConditionalSerialization
    {
        public bool IsSecret { get; set; }
        public string SecretProperty { get { return "should not see me"; } }
        // Ensure "normal" conditional property serialization is not broken
        public bool ShouldSerializeSecretProperty()
        {
            return false;
        }
        #region IConditionalSerialization Members
        bool IConditionalSerialization.ShouldSerialize()
        {
            return !IsSecret;
        }
        #endregion
    }
    public class TestClass
    {
        public static void Test()
        {
            Predicate<object> filter = (o) => 
                {
                    var conditional = o as IConditionalSerialization;
                    return conditional == null || conditional.ShouldSerialize();
                };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new ShouldSerializeContractResolver(filter),
            };
            var ok = new ConditionalSerializationObject { IsSecret = false };
            var notOk = new ConditionalSerializationObject { IsSecret = true };
            Test(ok, settings);
            Test(new { Public = ok, Private = notOk }, settings);
            Test(new [] { ok, notOk, ok, notOk }, settings);
            Test(new[,] {{ ok, notOk, ok, notOk }}, settings);
            Test(new { Array = new[,] { { ok, notOk, ok, notOk } } }, settings);
            try
            {
                Test(notOk, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown and not caught serializing root object " + notOk.GetType());
                Console.WriteLine(ex);
            }
        }
        static void Test<T>(T value, JsonSerializerSettings settings)
        {
            Console.WriteLine("Unfiltered object: ");
            Console.WriteLine(JToken.FromObject(value));
            var serializer = JsonSerializer.CreateDefault(settings);
            var token = JToken.FromObject(value, serializer);
            Console.WriteLine("Filtered object: ");
            Console.WriteLine(token);
            if (!token.SelectTokens("..IsSecret").All(t => JToken.DeepEquals(t, (JValue)false)))
            {
                throw new InvalidOperationException("token.SelectTokens(\"..IsSecret\").All(t => JToken.DeepEquals(t, (JValue)true))");
            }
            if (token.SelectTokens("..SecretProperty").Any())
            {
                throw new InvalidOperationException("token.SelectTokens(\"..SecretProperty\").Any()");
            }
            Console.WriteLine("Secret objects and properties were successfully filtered.");
            Console.WriteLine("");
        }
    }
