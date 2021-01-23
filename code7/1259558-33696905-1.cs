    [DataMember]
    public DateTime? Date
        {
            get
            {
                string date = string.Concat(this.Day, "/", this.Month, "/", this.Year);
                return Convert.ToDateTime(date);
            }
        }
      /*code for getters and setters for day, month, year and description about the holiday */
