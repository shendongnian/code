    public class EmployeeConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            List<Employee> employees = null;
            
            if (reader.TokenType == JsonToken.StartArray)
            {
                JArray arr = serializer.Deserialize<JArray>(reader);
                
                employees = new List<Employee>(arr.Count);
                
                var employeeMap = new Dictionary<int, Employee>();
                
                foreach (var item in arr)
                {
                    if (item.Type == JTokenType.Object)
                    {
                        var employee = item.ToObject<Employee>();
                        employees.Add(employee);
                        
                        int id = item["$id"].ToObject<int>();
                        employeeMap.Add(id, employee);
                    }
                    else if (item.Type == JTokenType.Integer)
                    {
                        Employee employee = null;
                        
                        int id = item.ToObject<int>();
                        
                        if (employeeMap.TryGetValue(id, out employee))
                        {
                            employees.Add(employee);
                        }
                    }
                }
            }
                
            return employees;
        }
        
        public override bool CanRead
        {
            get { return true; }
        }
        
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
