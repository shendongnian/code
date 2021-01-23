        [JsonProperty(PropertyName = "@Code")]
        public string ProductCode
        {
            get { return _productCode == null ? string.Empty : _productCode ; }
            set { _productCode = value.Trim(); }
        }
