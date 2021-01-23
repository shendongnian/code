        public override bool IsValid(object value)
        {
          this.SetupRegex();
          string input = Convert.ToString(value, (IFormatProvider) CultureInfo.CurrentCulture);
          if (string.IsNullOrEmpty(input))
            return true;
          Match match = this.Regex.Match(input);
          if (match.Success && match.Index == 0)
            return match.Length == input.Length;
          return false;
        }
