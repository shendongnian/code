    JsonResult json = Details();                         // returns JsonResult type object
    string ser = JsonConvert.SerializeObject(json.Data); // serializing JsonResult object (it will give you json string)
    object dec = JsonConvert.DeserializeObject(ser);     // deserializing Json string (it will deserialize Json string)
    JObject obj =  JObject.Parse(dec.ToString());        // it will parse deserialize Json object
    string name = obj["Data"].ToString();                // now after parsing deserialize Json object you can get individual values by key i.e.
    string name = obj["Data"].ToString();       // will give Data value
    string name = obj["result"].ToString();     // will give result value
