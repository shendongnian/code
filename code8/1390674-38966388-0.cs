    [Serializable]
    public class CustomFormBuilder
    {
        public string FormJson { get; set; }
        public CustomFormBuilder(string formJson)
        {
            FormJson = formJson;
        }
        public IForm<JObject> BuildJsonForm()
        {
            var schema = JObject.Parse(FormJson);
            var form = new FormBuilderJson(schema)
                .AddRemainingFields()
                .Build();
            return form;
        }
    }
