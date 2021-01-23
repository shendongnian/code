    internal bool IsSerializedObjectTypeSupported(object serializedObject)
    {
      bool flag = false;
      Type type = serializedObject.GetType();
      if (this._isBatchMode)
      {
        if (typeof (Visual).IsAssignableFrom(type) && type != typeof (FixedPage))
          flag = true;
      }
      else if (type == typeof (FixedDocumentSequence) || type == typeof (FixedDocument) || (type == typeof (FixedPage) || typeof (Visual).IsAssignableFrom(type)) || typeof (DocumentPaginator).IsAssignableFrom(type))
        flag = true;
      return flag;
    }
