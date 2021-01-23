    this.ErrorMessage = string.Empty;
      int parseInt = 0;
      if (!int.TryParse(data[0], out parseInt))
      {
        this.ErrorMessage += "Error Parsing the account number! data was: " + data[0];
        this.AcctNumber = -1;
      }
      else
      {
        this.AcctNumber = parseInt;
      }
