    /// <summary>
    /// Translates the current instance into a JsonObject.
    /// </summary>
    /// <returns>The current instance as a JsonObject.</returns>
    public JsonObject Serialise()
    {
        JsonObject jsonObject = new JsonObject();
        jsonObject.Add("Number", this.number.HasValue ? JsonValue.CreateNumberValue(this.number.Value) : JsonValue.CreateNullValue());
        jsonObject.Add("Category", (!string.IsNullOrEmpty(this.category)) ? JsonValue.CreateStringValue(this.category) : JsonValue.CreateNullValue());
        jsonObject.Add("Comment", (!string.IsNullOrEmpty(this.comment)) ? JsonValue.CreateStringValue(this.comment) : JsonValue.CreateNullValue());
        if (this.performer != null)
        {
            jsonObject.Add("Performer", this.performer.Serialise());
        }
        else
        {
            jsonObject.Add("Performer", JsonValue.CreateNullValue());
        }
        if (this.castImages != null)
        {
            jsonObject.Add("CastImages", this.castImages.Serialise());
        }
        else
        {
            jsonObject.Add("CastImages", JsonValue.CreateNullValue());
        }
        jsonObject.Add("CastClip", this.castClip != null ? JsonValue.CreateStringValue(this.castClip.ToString()) : JsonValue.CreateNullValue());
        return jsonObject;
    }
