    var sample = new List<SampleClass>
    {
        new SampleClass()
        {
            columns = new List<SampleItem>()
            {
                new SampleItem() {title = "NAME" },
                new SampleItem() {title = "COUNTY" },
            },
            data = new List<List<string>>()
            {
                new List<string> { "John Doe", "Fresno" },
                new List<string> { "Billy", "Fresno" },
                new List<string> { "Tom", "Kern" },
                new List<string> { "King Smith", "Kings" },
            }
        }
    };
    var serializer = new JavaScriptSerializer();
    var json = serializer.Serialize(sample);
