    using Newtonsoft.Json;
    public class CheckBoxResultsJson
    {
        public List<boCheckBoxResult> checkboxes { get; set; }
    }
    public class boCheckBoxResult
    {
        public int id { get; set; }
        public bool ischecked { get; set; }
    }
