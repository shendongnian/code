json
"SalesRevenueAmount": [
    {
       "@CurrencyISOAlpha3Code": "USD",
       "$": 1000000
    },
    {
       "@CurrencyISOAlpha3Code": "CAD",
       "$": 1040000
    }
]
Should be deserialized into a collection of models as follows:
csharp
public class SalesRevenueAmount {
    public string CurrencyISOAlpha3Code { get; set; }
    public string Value { get; set; }
}
###Easiest Solution
The easiest solution, and most obvious is to affix the `JsonProperty` attribute to each property that I expect to have this `@` or `$` naming convention.
csharp
public class SalesRevenueAmount {
    [JsonProperty("@CurrencyISOAlpha3Code")]
    public string CurrencyISOAlpha3Code { get; set; }
    [JsonProperty("$")]
    public string Value { get; set; }
}
This is relatively simple to do, but also extremely prone to error. I'm also not a fan of affixing infrastructure-layer specific attributes to my models like this if it can be avoided.
###Better solution
Therefore, I surmised that a ***better solution*** would be one where I'm not forced to maintain and hand write these annotations that are so prone to error. Sure, I still have to write the property name itself, but those can be easily refactored within Visual Studio or whatever IDE you prefer. Magic strings in the attributes on the other hand wouldn't be caught until runtime or unit tests were failing.
Therefore, I wanted something a little more automatic, robust, and DRY. After digging into Newtonsoft JSON, I finally came up with a solution with which I was satisfied. I created a simple `JsonConverter` that I'm calling `BadgerFishJsonConverter`.
The current implementation only handles deserialization, but it wouldn't be too hard to adapt it to do serialization. I just don't have the need yet. If I do in the future, I will come back to update my answer.
csharp
public class BadgerFishJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return true;
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var source = JObject.Load(reader);
        //Since we can't modify the internal collections, first we will get all the paths.
        //Then we will proceed to rename them.
        var paths = new List<string>();
        collectPaths(source, paths);
        renameProperties(source, paths);
        return source.ToObject(objectType);
    }
    private void collectPaths(JToken token, ICollection<string> collection)
    {
        switch (token.Type)
        {
            case JTokenType.Object:
            case JTokenType.Array:
                foreach (var child in token)
                {
                    collectPaths(child, collection);
                }
                break;
            case JTokenType.Property:
                var property = (JProperty)token;
                if (shouldRenameProperty(property.Name))
                {
                    collection.Add(property.Path);
                }
                foreach (var child in property)
                {
                    collectPaths(child, collection);
                }
                break;
            default:
                break;
        }
    }
    private void renameProperties(JObject source, ICollection<string> paths)
    {
        foreach (var path in paths)
        {
            var token = source.SelectToken(path);
            token.Rename(prop => transformPropertyName(prop));
        }
    }
    private bool shouldRenameProperty(string propertyName)
    {
        return propertyName.StartsWith("@") || propertyName.Equals("$");
    }
    private static string transformPropertyName(JProperty property)
    {
        if (property.Name.StartsWith("@"))
        {
            return property.Name.Substring(1);
        }
        else if (property.Name.Equals("$"))
        {
            return "Value";
        }
        else
        {
            return property.Name;
        }
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
If I wanted to spend a lot more time on this, it definitely be written to be much more performant, but I simply didn't need that speed for my project.
The `ReadJson` method it currently utilizing `JObject.Load(reader)` which converts the JSON to a `JObject` as is using the default implementation.
Then, I recurse over the graph of that object, collecting the paths to properties which I want to rename. This is because I can't rename them during enumeration because that would modify the collection being iterated which is not allowed for obvious reasons.
After collecting the paths, I iterate the paths, renaming those specific properties. This process first removes the old property, and then adds a new one with the new name.
For those so inclined, a more savvy and efficient implementation would do all this during the deserialization phase of the `JsonReader` building up the `JObject`, renaming the properties as they are read from the reader.
###Usage
Usage is simple and is as follows:
csharp
var jsonSettings = new JsonSerializerSettings();
jsonSettings.Converters.Add(new BadgerFishJsonConverter());
var obj = JsonConvert.DeserializeObject<SalesRevenueAmounts>(json, jsonSettings); 
Given the following two models:
csharp
public class SalesRevenueAmount
{
    public string CurrencyISOAlpha3Code { get; set; }
    public string Value { get; set; }
}
public class SalesRevenueAmounts
{
    public IEnumerable<SalesRevenueAmount> SalesRevenueAmount { get; set; }
}
###Additional References
As part of my solution, I utilized [this Rename extension](https://stackoverflow.com/a/47269811/1195273) from user [Brian Rogers](https://stackoverflow.com/users/10263) which I found helps tidy up my code a bit. I added the ability to pass in a name provider function by simply changing the argument to a `Func<JProperty, string>` so that I could control how the provider name was created.
Full implementation, below:
csharp
public static class Extensions
{
    public static void Rename(this JToken token, string newName)
    {
        token.Rename(prop => newName);
    }
    public static void Rename(this JToken token, Func<JProperty, string> nameProvider)
    {
        if (token == null)
            throw new ArgumentNullException("token", "Cannot rename a null token");
        JProperty property;
        if (token.Type == JTokenType.Property)
        {
            if (token.Parent == null)
                throw new InvalidOperationException("Cannot rename a property with no parent");
            property = (JProperty)token;
        }
        else
        {
            if (token.Parent == null || token.Parent.Type != JTokenType.Property)
                throw new InvalidOperationException("This token's parent is not a JProperty; cannot rename");
            property = (JProperty)token.Parent;
        }
        var newName = nameProvider.Invoke(property);
        var newProperty = new JProperty(newName, property.Value);
        property.Replace(newProperty);
    }
}
Hope this serves to save someone time in the future.
