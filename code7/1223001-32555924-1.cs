            Unit unit = new Unit();
            unit.UnitId = new CustomerType()
            {
                CustomId = 1001,
                Type = "Customer"
            };
            //generate test json string
            string jsonTest = JsonConvert.SerializeObject(unit);
            
            //convert to dynamic
            var result = JsonConvert.DeserializeObject<dynamic>(jsonTest);
            Console.WriteLine(result.UnitId.CustomId);
            Console.WriteLine(result.UnitId.Type);
