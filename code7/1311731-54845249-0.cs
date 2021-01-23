        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        private class node
        {
            public node()
            {
                this.children = new List<node>();
            }
            public node(string _value, List<node> _children = null, bool _isChecked = false)
            {
                Value = _value;
                isChecked = _isChecked;
                if (_children != null)
                {
                    children = _children;
                }
            }
            [JsonProperty("value")]
            public string Value { get; set; }
            [JsonProperty("isChecked")]
            public bool isChecked { get; set; }
            [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
            public List<node> children { get; set; }
            [JsonIgnore]
            public string JSon
            {
                get
                {
                    return JsonConvert.SerializeObject(this);
                }
            }
        }
