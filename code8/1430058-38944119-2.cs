    public class JsonBuildBlockConverter : AbstractJsonCreationConverter<AbstractBuildBlock>
    {
        protected override AbstractBuildBlock Create(Type objectType, JObject jsonObject)
        {
            var type = jsonObject["contentType"].ToString();
            switch(type)
            {
                case "text":
                    return new TextBlock();
                default:
                    return null;
            }
        }
    }
