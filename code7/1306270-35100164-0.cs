        class MyClass<Tkey, Tvalue> { };
        
        private IEnumerable<string> GetTypeParameterNames(Type fType)
        {
            List<string> result = new List<string>();
            if(fType.IsGenericType)
            {
                var lGenericTypeDefinition = fType.GetGenericTypeDefinition();
                foreach(var lGenericArgument in lGenericTypeDefinition.GetGenericArguments())
                {
                    result.Add(lGenericArgument.Name);
                }
            }
            return result;
        }
        private void AnalyseObject(object Object)
        {
            if (Object != null)
            {
                var lTypeParameterNames = GetTypeParameterNames(Object.GetType());
                foreach (var name in lTypeParameterNames)
                {
                    textBox1.AppendText(name + Environment.NewLine);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var object1 = new MyClass<string, string>();
            AnalyseObject(object1);
            var object2 = new List<string>();
            AnalyseObject(object2);
            AnalyseObject("SomeString");
        }
