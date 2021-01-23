    public class Part
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public Part(string str)
        {
            int location_of_bracket_start = str.LastIndexOf("[");
            if(location_of_bracket_start == -1)
                throw new Exception("Unexpected format");
            Name = str.Substring(0, location_of_bracket_start);
            string rest = str.Substring(location_of_bracket_start);
            Index = int.Parse(rest.Substring(1, rest.Length - 2));
        }
        public string ConvertToStringFormat()
        {
            return string.Format("/{0}[{1}]", Name, Index);
        }
    }
