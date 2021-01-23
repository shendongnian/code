    private object DeserializeBody(XmlDictionaryReader reader, MessageVersion version, XmlSerializer serializer, MessagePartDescription returnPart, MessagePartDescriptionCollection bodyParts, object[] parameters, bool isRequest)
    {
      try
      {
        if (reader == null)
          throw DiagnosticUtility.ExceptionUtility.ThrowHelperError((Exception) new ArgumentNullException("reader"));
        if (parameters == null)
          throw DiagnosticUtility.ExceptionUtility.ThrowHelperError((Exception) new ArgumentNullException("parameters"));
        object obj = (object) null;
        if (serializer == null || reader.NodeType == XmlNodeType.EndElement)
          return (object) null;
        object[] objArray = (object[]) serializer.Deserialize((XmlReader) reader, this.isEncoded ? XmlSerializerOperationFormatter.GetEncoding(version.Envelope) : (string) null);
        int num = 0;
        if (OperationFormatter.IsValidReturnValue(returnPart))
          obj = objArray[num++];
        for (int index = 0; index < bodyParts.Count; ++index)
          parameters[((Collection<MessagePartDescription>) bodyParts)[index].Index] = objArray[num++];
        return obj;
      }
      catch (InvalidOperationException ex)
      {
        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError((Exception) new CommunicationException(System.ServiceModel.SR.GetString(isRequest ? "SFxErrorDeserializingRequestBody" : "SFxErrorDeserializingReplyBody", new object[1]
        {
          (object) this.OperationName
        }), (Exception) ex));
      }
