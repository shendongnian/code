    private void setObjectProperties(float? param1 = null, bool? param2 = null)
    {
        if (param1.HasValue) {
          this.param1 = param1.Value;
        }
        if (param2.HasValue) {
          this.param2 = param2.Value;
        }
    }
