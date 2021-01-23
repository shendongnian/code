            // Advance to the text value of the element.
            if (reader.NodeType == XmlNodeType.Element)
                reader.Read();
            // But make sure there is text value!
            if (reader.NodeType == XmlNodeType.Text)
            {
                var charBuffer = new char[4096];
                using (var fileStream = File.OpenWrite(path))
                using (var transform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces))
                using (var cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write))
                using (var bufferedStream = new BufferedStream(cryptoStream, charBuffer.Length))
                {
                    int charRead;
                    while ((charRead = reader.ReadValueChunk(charBuffer, 0, charBuffer.Length)) != 0)
                    {
                        for (int i = 0; i < charRead; i++)
                            bufferedStream.WriteByte(checked((byte)charBuffer[i]));
                    }
                }
                Debug.WriteLine("Wrote " + path);
            }
