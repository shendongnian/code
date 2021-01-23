    /// <summary>
    /// Translates the current instance into a JsonObject.
    /// </summary>
    /// <returns>The current instance as a JsonObject.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CastItem", Justification = "Reviewed.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "UnhandledException", Justification = "Reviewed.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
    public JsonObject Serialise()
    {
        JsonObject jsonObject = new JsonObject();
        try
        {
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
            // The BitmapImage properties of CastItem are cached values from calls to ResizeImage and BrightenImage to provide a fluid user experience.
            // These properties are only meant to be sent back and forth between CastListPage and CastPage to avoid repeated resizing/brightening, but are
            // not intended to be permanently saved anywhere. The memory location for the actual pixel data of these cached versions is consequently
            // TemporaryFolder. The original image references are those stored with the CastImages object, from which these cached versions are generated.
            jsonObject.Add("Image0", this.Image0 != null ? JsonValue.CreateStringValue(this.Image0.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Image1", this.Image1 != null ? JsonValue.CreateStringValue(this.Image1.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Image2", this.Image2 != null ? JsonValue.CreateStringValue(this.Image2.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Image3", this.Image3 != null ? JsonValue.CreateStringValue(this.Image3.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Image4", this.Image4 != null ? JsonValue.CreateStringValue(this.Image4.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Image5", this.Image5 != null ? JsonValue.CreateStringValue(this.Image5.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("Background", this.Background != null ? JsonValue.CreateStringValue(this.Background.UriSource.OriginalString) : JsonValue.CreateNullValue());
            jsonObject.Add("CastClip", this.castClip != null ? JsonValue.CreateStringValue(this.castClip.ToString()) : JsonValue.CreateNullValue());
        }
        catch (Exception exception)
        {
            // While the executable is _not_ run under the Visual Studio debugger, a repeated back and forth navigation between CastListPage <-> CastPage used to crash the
            // application: E_POINTER - Pointer that is not valid. The CLR stack trace provided by the Defrag Tools Series team points to this method (CastItem.Serialise()).
            // I was so far unable to determine why this NullReferenceException could not be reproduced when run under the Visual Studio debugger: under the debugger, everything
            // works just fine. Another puzzle is the effect of this try-catch-block now wrapping the whole method: The E_POINTER crash has disappeared completely. The app
            // navigates stably between CastListPage <-> CastPage, whether under the Visual Studio debugger or not. The following line of code is never executed, this exception
            // branch is never reached: The wrapping into a try-catch-block alone does the trick: What a Magic wrap!
            this.WriteMessage(string.Format("UnhandledException - CastItem.Serialise - {0}", exception.ToString()));
        }
        return jsonObject;
    }
