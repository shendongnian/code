    foreach (JsonValue groupValue in jsonData1)
        {
                ...
                string tipe = groupObject["tipe"].GetString();
                string bundleName="";//This line should be added;
                var bundleObj = groupObject["bundle"];
                if (bundleObj.ValueType == JsonValueType.Array)
                {
                    JsonArray bundle = bundleObj.GetArray();
                    foreach (JsonValue groupValue1 in bundle)
                {
                    JsonObject groupObject1 = groupValue1.GetObject();
                    bundleName = groupObject1["bundle_file"].GetString();//This line should be edited;
                        ...
                }
            }
            BukuAudio file = new BukuAudio();
            file.SKU = nid;
            file.Judul = title;
            file.Deskripsi = deskripsi;
            file.Tipe = tipe;
            file.BundleName=bundleName;//This line should be added.
