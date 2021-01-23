    using (var pbReader = new Google.Protobuf.CodedInputStream(clientStream, true))
    {
        var inRequest = new ProtoMsgStructRequest();
        pbReader.ReadMessage(inRequest);
        {
            var outResponse = new ProtoMsgStructResponse();
            using (var pbWriter = new Google.Protobuf.CodedOutputStream(clientStream, true))
            {
                pbWriter.WriteMessage(outResponse);
            }
        }
    }
