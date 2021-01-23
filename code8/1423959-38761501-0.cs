     public override IEnumerable<IRow> Extract(IUnstructuredReader input, IUpdatableRow output)
        {
            // Json.Net
            using (var reader = new StreamReader(input.BaseStream))
            {
                // Parse Json
                //  TODO: Json.Net fails with empty input files
                var text = reader.ReadToEnd();
                var decr = Encryption.Decryptor.Decrypt(text);
                var root = JToken.Parse(decr);
                // Rows
                //  All objects are represented as rows
                foreach (JObject o in SelectChildren(root, this.rowpath))
                {
                    // All fields are represented as columns
                    this.JObjectToRow(o, output);
                    yield return output.AsReadOnly();
                }
            }
        }
