        class GOO {
          string author { get; set; }
          string date { get; set; }
          string subject { get; set; }
          [JsonProperty(Required = Newtonsoft.Json.Required.AllowNull)]
          List<string> approvals { get; set; }
        }
