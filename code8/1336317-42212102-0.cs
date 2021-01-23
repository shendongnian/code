    var json = @"{
            'Name':'Peter',
            'Age':22,
            'CourseDet':{
                    'CourseName':'CS',
                    'CourseDescription':'Computer Science',
                    },
            'Subjects':['Computer Languages','Operating Systems']
            }";
            var expConverter = new ExpandoObjectConverter();
            dynamic deserializedObject = JsonConvert.DeserializeObject<ExpandoObject>(json, expConverter);
            var serializer = new YamlDotNet.Serialization.Serializer();
            string yaml = serializer.Serialize(deserializedObject);
