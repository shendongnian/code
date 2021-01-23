        {
            "data": [{
                "test": {
                    "col1": "123",
                    "col2": "name"
                }, {
                "test": {
                    "col1": "345",
                    "col2": "name2"
                }, /* etc */
            ]
        }
    This way, `data` represents an array and you can deserialize it as such:
        class Root 
        { 
            List<Data> Data  { get; set; };
        }
        class Data
        {
            Test Test { get; set; }
        }
 
        JsonConvert.DeserializeObject<Root>(json);
