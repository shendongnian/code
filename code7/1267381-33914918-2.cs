    using (var connection = new SqlConnection("Connection String"))
    using (var otherDisposableObject = new ....)
    using (var anotherDisposableObject = new ....)
    using (var andAnotherDisposableObject = new ....)
    {
    } //andAnotherDisposableObject, anotherDisposableObject, otherDisposableObject and connection all disposed
