        public static void AddOuterElement(string fileName, string elementName)
        {
            var startElement = string.Format(@"<{0}>", elementName);
            var endElement = string.Format(@"</{0}>", elementName);
            var tmpName = Path.GetTempFileName();
            try
            {
                using (var writer = new StreamWriter(tmpName, false, Encoding.UTF8))
                {
                    writer.WriteLine(startElement);
                    foreach (var line in File.ReadLines(fileName))  // Reads lines incrementally rather than all at once.
                        writer.WriteLine(line);
                    writer.WriteLine(endElement);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                try
                {
                    System.IO.File.Delete(tmpName);
                }
                catch (Exception)
                {
                }
                throw;
            }
            System.IO.File.Delete(fileName);
            System.IO.File.Move(tmpName, fileName);
        }
