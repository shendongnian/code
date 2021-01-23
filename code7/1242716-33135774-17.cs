    public class NodePath : List<Part>
    {
        public NodePath(string path)
        {
            string[] parts = path.Split(new []{"/"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                this.Add(new Part(part));
            }
        }
        public string ConvertToStringFormat()
        {
            return string.Join("", this.Select(x => x.ConvertToStringFormat()));
        }
    }
