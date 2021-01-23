    public class TemplateParser
    {
        private string _content;
        public Dictionary<string, object> Variables { get; } = new Dictionary<string, object>();
        public TemplateParser(string filepath)
        {
            try
            {
                _content = File.ReadAllText(filepath);
            }
            catch (IOException)
            {
                Console.WriteLine("File could not be found on the following location:\n" + filepath);
            }
        }
        public void Parse()
        {
            var placeholder = "";
            var beginIndex = 0;
            var busy = false;
            for (var i = 0; i < _content.Length; i++)
                switch (_content[i])
                {
                    case '{':
                        placeholder = "";
                        busy = true;
                        beginIndex = i;
                        break;
                    case '}':
                        if (placeholder != "")
                        {
                            var position = placeholder.IndexOf('.');
                            var success = false;
                            try
                            {
                                object pValue;
                                if (position >= 0)
                                {
                                    var pName = placeholder.Substring(position + 1);
                                    pValue = GetPropertyValue(Variables[placeholder.Substring(0, position)], pName);
                                }
                                else pValue = Variables[placeholder];
                                if (pValue == null)
                                {
                                    Console.WriteLine("Property not found");
                                    throw new KeyNotFoundException("Property not found");
                                }
                                _content = _content.Replace("{" + placeholder + "}", pValue.ToString());
                                success = true;
                            }
                            catch (KeyNotFoundException)
                            {
                                Console.WriteLine("WARNING: Placeholder {" + placeholder + "} is unknown");
                                _content = _content.Replace("{" + placeholder + "}", "x");
                            }
                            busy = false;
                            if (success) i = beginIndex;
                        }
                        break;
                    default:
                        if (busy) placeholder += _content[i];
                        break;
                }
        }
        private static object GetPropertyValue(object obj, string propertyName)
        {
            var pi = obj.GetType().GetProperties().FirstOrDefault(x => x.Name == propertyName);
            FieldInfo fi = null;
            if (pi == null)
                foreach (var x in obj.GetType().GetFields().Where(x => x.Name == propertyName))
                {
                    fi = x;
                    break;
                }
            return pi != null ? pi.GetValue(obj) : fi?.GetValue(obj);
        }
        public string[] ToArray() => _content.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    }
