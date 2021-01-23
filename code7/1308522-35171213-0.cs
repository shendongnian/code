    /// <summary>The date, in the format "yyyy-mm-dd", if this is an all-day event.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("date")]
            public virtual string Date { get; set; } 
    
            /// <summary>The time, as a combined date-time value (formatted according to RFC3339). A time zone offset is
            /// required unless a time zone is explicitly specified in timeZone.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("dateTime")]
            public virtual string DateTimeRaw { get; set; }
    
            /// <summary><seealso cref="System.DateTime"/> representation of <see cref="DateTimeRaw"/>.</summary>
            [Newtonsoft.Json.JsonIgnore]
            public virtual System.Nullable<System.DateTime> DateTime
            {
                get
                {
                    return Google.Apis.Util.Utilities.GetDateTimeFromString(DateTimeRaw);
                }
                set
                {
                    DateTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
                }
            }
