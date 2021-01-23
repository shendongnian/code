    var bundleObj = groupObject["bundle"];
    if (bundleObj.ValueType == JsonValueType.Array)
    {
           JsonArray bundle = bundleObj.GetArray();
           foreach (JsonValue groupValue1 in bundle)
           {
               JsonObject groupObject1 = groupValue1.GetObject();
               string bundleName = groupObject1["bundle_file"].GetString();
               string pathFile = groupObject1["path_file"].GetString();
           }
    }
