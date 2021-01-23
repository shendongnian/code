    class Telegram
        {
            private dynamic _payload = new ExpandoObject();
            public dynamic payload
            {
                get
                {
                    return _payload;
                }
            }
            public string ToJson()
            {
                ...
            }
        }
    
