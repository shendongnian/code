    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"
    [
      {
        ""ParentVariantName"": ""Variant1"",
        ..... Removed to save space. Insert your input JSON here with " changed to "" ....
    ";
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                foreach (var item in data)
                    foreach (var test in item.TestList)
                    {
                        var list = new List<Model>();
                        foreach (var pair in test.SubVariantsList)
                        {
                            Model.UpsertToList(list, pair.SourceSubVariantModel);
                            Model.UpsertToList(list, pair.TargetSubVariantModel);
                        }
                        test.SubVariantsList = Newtonsoft.Json.Linq.JToken.FromObject(list);
                    }
    
                Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
                Console.ReadKey();
            }
        }
    
        class Model
        {
            public int Id;
            public string Name;
            public int DiffPerc;
    
            public static void UpsertToList(List<Model> list, dynamic sourceObject)
            {
                var item = list.FindLast(model => sourceObject.Id == model.Id);
                if (item == null)
                    list.Add(new Model(sourceObject));
                else
                    item.Update(sourceObject);
            }
    
            Model(dynamic sourceObject)
            {
                Id = sourceObject.Id;
                Update(sourceObject);
            }
    
            void Update(dynamic sourceObject)
            {
                Name = sourceObject.Name;
                var diffPerc = sourceObject["DiffPerc"];
                if (diffPerc == null)
                    diffPerc = sourceObject["SourceValue"];
                if (diffPerc == null)
                    diffPerc = sourceObject["TargetValue"];
                if (diffPerc != null)
                    DiffPerc = diffPerc;
            }
        }
    }
