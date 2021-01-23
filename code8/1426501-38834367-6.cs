        [IgnoreDataMember]
        public DateTime? Created { get; set; }
        [DataMember(Name = "Created")]
        string CreatedString
        {
            get
            {
                if (Created == null)
                    return null;
                // From https://stackoverflow.com/questions/114983/given-a-datetime-object-how-do-i-get-a-iso-8601-date-in-string-format
                return Created.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Created = null;
                else
                    Created = DateTime.Parse(value);
            }
        }
        [DataMember]
        public DateTime? Modified { get; set; }
    }
