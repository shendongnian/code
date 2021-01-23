    public class TestClass
    {
        public static void Test()
        {
            var container1 = new Container1 { Name = "name", ProductId = 101, Common = new CommonFields { Id = "1401", Time = DateTime.Today.Ticks } };
            var container2 = new Container2 { Group = Guid.NewGuid(), Common = new CommonFields { Id = "2401", Time = DateTime.Today.Ticks } };
            Test(container1);
            Test(container2);
        }
        private static void Test<T>(T container) where T : class, IHasCommonFields
        {
            var json = JsonConvert.SerializeObject(container, Formatting.Indented);
            Debug.WriteLine(json);
            var containerback = JsonConvert.DeserializeObject<T>(json);
            var json2 = JsonConvert.SerializeObject(containerback, Formatting.Indented);
            Debug.Assert(json == json2); // No assert
            if (container.Common != null)
            {
                Debug.Assert(container.Common.Id == containerback.Common.Id); // No assert
                Debug.Assert(container.Common.Time == containerback.Common.Time); // No assert
            }
        }
    }
