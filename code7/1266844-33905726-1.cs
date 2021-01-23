            var ms = new MemoryStream();
            serializer.Serialize(ms, new InvoiceChangeRequest {
                Styrefelter = new ControlFields {  Opera="test"}
            });
            var s = Encoding.UTF8.GetString(ms.ToArray());
