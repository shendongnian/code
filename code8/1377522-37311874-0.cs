            using (var writeStream = blockBlob.OpenWrite())
            {
                using (var writer = new StreamWriter(writeStream))
                {
                    table.WriteXml(writer, XmlWriteMode.WriteSchema);
                }
            }
