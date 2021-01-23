        static void Main(string[] args)
        {
            Assembly asm = Assembly.GetAssembly(typeof(Program));
            using (var stream = asm.GetManifestResourceStream("ConsoleApplication1.json.json"))
            {
                TextReader tr = new StreamReader(stream);
                var json = tr.ReadToEnd();
                var thing = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            }
        }
