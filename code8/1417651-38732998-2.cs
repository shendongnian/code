    public long? ContentLength
    {
        get
        {
            // 'Content-Length' can only hold one value. So either we get 'null' back or a boxed long value.
            object storedValue = GetParsedValues(HttpKnownHeaderNames.ContentLength);
            // Only try to calculate the length if the user didn't set the value explicitly using the setter.
            if (!_contentLengthSet && (storedValue == null))
            {
                // If we don't have a value for Content-Length in the store, try to let the content calculate
                // it's length. If the content object is able to calculate the length, we'll store it in the
                // store.
                long? calculatedLength = _calculateLengthFunc();
                if (calculatedLength != null)
                {
                    SetParsedValue(HttpKnownHeaderNames.ContentLength, (object)calculatedLength.Value);
                }
                return calculatedLength;
            }
            if (storedValue == null)
            {
                return null;
            }
            else
            {
                return (long)storedValue;
            }
        }
        set
        {
            SetOrRemoveParsedValue(HttpKnownHeaderNames.ContentLength, value); // box long value
            _contentLengthSet = true;
        }
    }
