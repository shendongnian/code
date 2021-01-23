    void Main()
    {
        var jsonStrings = new[]
        {
            "{ \"prop\": \"identifier\" }",
            "{ \"prop\": { \"complex\": \"object\" } }"
        };
    
        jsonStrings.Select(json => JsonConvert.DeserializeObject<Test>(json)).Dump();
    }
    
    public class Test
    {
        [JsonProperty("prop")]
        public dynamic prop { get; set; }
    
        [JsonIgnore]
        public PropertyValue Property
        {
            get
            {
                if (prop is string)
                    return new IdentifierProperty(prop as string);
                return new ExpressionProperty(((JObject)prop).ToObject<Expression>());
            }
        }
    }
    
    public abstract class PropertyValue
    {
    }
    
    public class IdentifierProperty : PropertyValue
    {
        public IdentifierProperty(string identifier)
        {
            Identifier = identifier;
        }
    
        public string Identifier { get; }
    
        public override string ToString() => Identifier;
    }
    
    public class ExpressionProperty : PropertyValue
    {
        public ExpressionProperty(Expression expression)
        {
            Expression = expression;
        }
    
        public Expression Expression { get; }
    
        public override string ToString() => Expression.ToString();
    }
    
    public class Expression
    {
        public string complex { get; set; }
    
        public override string ToString() => $"complex: {complex}";
    }
