    [JsonIgnore]
    public bool? IsActiveBool {
        get {
            bool? result = null;
            if (IsActive != null)
            {
                if (TryConvertToBoolean(IsActive , out result)) // <-- Your method here
                {
                    return result;
                }
            }
            return null;
       }
    }
