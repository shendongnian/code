        /// <summary>
        /// The enum flag associated with the rule, if applicable.  CAN be null.
        /// </summary>
        [JsonIgnore]
        public System.Enum RuleFlagEnum { get; set; }
        [JsonProperty("RuleFlagEnum", TypeNameHandling = TypeNameHandling.All)]
        TypeWrapper RuleFlagEnumValue
        {
            get
            {
                return RuleFlagEnum == null ? null : TypeWrapper.CreateWrapper(RuleFlagEnum);
            }
            set
            {
                if (value == null || value.ObjectValue == null)
                    RuleFlagEnum = null;
                else
                    RuleFlagEnum = (Enum)value.ObjectValue;
            }
        }
