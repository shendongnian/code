        enum SplitState
        {
            InPrefix,
            InSplitProperty,
            InSplitArray,
            InPostfix,
        }
        public static void SplitJson(TextReader textReader, string tokenName, long maxItems, Func<int, TextWriter> createStream, Formatting formatting)
        {
            List<JProperty> prefixProperties = new List<JProperty>();
            List<JProperty> postFixProperties = new List<JProperty>();
            List<JsonWriter> writers = new List<JsonWriter>();
            SplitState state = SplitState.InPrefix;
            long count = 0;
            try
            {
                using (var reader = new JsonTextReader(textReader))
                {
                    bool doRead = true;
                    while (doRead ? reader.Read() : true)
                    {
                        doRead = true;
                        if (reader.TokenType == JsonToken.Comment || reader.TokenType == JsonToken.None)
                            continue;
                        if (reader.Depth == 0)
                        {
                            if (reader.TokenType != JsonToken.StartObject && reader.TokenType != JsonToken.EndObject)
                                throw new JsonException("JSON root container is not an Object");
                        }
                        else if (reader.Depth == 1 && reader.TokenType == JsonToken.PropertyName)
                        {
                            if ((string)reader.Value == tokenName)
                            {
                                state = SplitState.InSplitProperty;
                            }
                            else
                            {
                                if (state == SplitState.InSplitProperty)
                                    state = SplitState.InPostfix;
                                var property = JProperty.Load(reader);
                                doRead = false; // JProperty.Load() will have already advanced the reader.
                                if (state == SplitState.InPrefix)
                                {
                                    prefixProperties.Add(property);
                                }
                                else
                                {
                                    postFixProperties.Add(property);
                                }
                            }
                        }
                        else if (reader.Depth == 1 && reader.TokenType == JsonToken.StartArray && state == SplitState.InSplitProperty)
                        {
                            state = SplitState.InSplitArray;
                        }
                        else if (reader.Depth == 1 && reader.TokenType == JsonToken.EndArray && state == SplitState.InSplitArray)
                        {
                            state = SplitState.InSplitProperty;
                        }
                        else if (state == SplitState.InSplitArray && reader.Depth == 2)
                        {
                            if (count % maxItems == 0)
                            {
                                var writer = new JsonTextWriter(createStream(writers.Count)) { Formatting = formatting };
                                writers.Add(writer);
                                writer.WriteStartObject();
                                foreach (var property in prefixProperties)
                                    property.WriteTo(writer);
                                writer.WritePropertyName(tokenName);
                                writer.WriteStartArray();
                            }
                            count++;
                            writers.Last().WriteToken(reader, true);
                        }
                        else
                        {
                            throw new JsonException("Internal error");
                        }
                    }
                }
                foreach (var writer in writers)
                    using (writer)
                    {
                        writer.WriteEndArray();
                        foreach (var property in postFixProperties)
                            property.WriteTo(writer);
                        writer.WriteEndObject();
                    }
            }
            finally
            {
                // Make sure files are closed in the event of an exception.
                foreach (var writer in writers)
                    using (writer)
                    {
                    }
            }
        }
