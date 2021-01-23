using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
namespace JsonConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var jo = JObject.Parse(File.ReadAllText(@"test.json"));
            Console.WriteLine($"BEFORE:\r\n{jo}");
            jo.RemoveNullAndEmptyProperties();
            Console.WriteLine($"AFTER:\r\n{jo}");
        }
    }
    public static class JObjectExtensions
    {
        public static JObject RemoveNullAndEmptyProperties(this JObject jObject)
        {
            while (jObject.Descendants().Any(jt => jt.Type == JTokenType.Property && (jt.Values().All(a => a.Type == JTokenType.Null) || !jt.Values().Any())))
                foreach (var jt in jObject.Descendants().Where(jt => jt.Type == JTokenType.Property && (jt.Values().All(a => a.Type == JTokenType.Null) || !jt.Values().Any())).ToArray())
                    jt.Remove();
            return jObject;
        }
    }
}
The following is the program output:
    BEFORE:
    {
      "propertyWithValue": "",
      "propertyWithObjectWithProperties": {
        "nestedPropertyWithValue": "",
        "nestedPropertyWithNull": null
      },
      "propertyWithEmptyObject": {},
      "propertyWithObjectWithPropertyWithNull": {
        "nestedPropertyWithNull": null
      },
      "propertyWithNull": null,
      "emptyArray": [],
      "arrayWithNulls": [
        null,
        null
      ],
      "arrayWithObjects": [
        {
          "propertyWithValue": ""
        },
        {
          "propertyWithNull": null
        }
      ]
    }
    AFTER:
    {
      "propertyWithValue": "",
      "propertyWithObjectWithProperties": {
        "nestedPropertyWithValue": ""
      },
      "arrayWithObjects": [
        {
          "propertyWithValue": ""
        },
        {}
      ]
    }
