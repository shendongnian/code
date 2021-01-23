    public T Value {
        get {
            if (!hasValue) {
                ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
            }
            return value;
        }
    }
