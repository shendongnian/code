    var sb = new StringBuilder();
    using (var sw = new StringWriter(sb))
    using (var jsonWriter = new JsonTextWriter(sw))
    {
        var countAwait = 0;
        jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
        jsonWriter.WriteStartObject(); // Write the opening of the root object
        jsonWriter.WritePropertyName(RowElement); // Write the "Items" property name
        jsonWriter.WriteStartArray(); // Write the opening of the "Items" array
        for (int row = firstRow; row <= end.Row; row++)
        {
            count++;
            countAwait++;
            if (countAwait >= 10)
            {
                ResultText = "Reading record " + count;
                countAwait = 0;
            }
            jsonWriter.WriteStartObject(); // Write the beginning of an entry in the "Items" array
            for (int col = start.Column; col <= end.Column; col++)
            {
                jsonWriter.WritePropertyName(fieldNames[col]);
                jsonWriter.WriteValue(GetCellStringValue(ws, row, col));
            }
            jsonWriter.WriteEndObject(); // Write the ending of an entry in the "Items" array
        }
        jsonWriter.WriteEndArray(); // Write the closing of the "Items" array.
        jsonWriter.WriteEndObject(); // Write the closing of the root object
        // No need to close explicitly when inside a using statement
    }
