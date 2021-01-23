    string jsonString = JsonWebUtil.ConvertArray( new object[] {
            "jsonrpc","2.0",
            "method","generateIntegers",
            "params", new object[] {
                "apiKey", "<REDACTED>",
                "n", 14,
                "min", 0,
                "max", 10,
                } ,
            "id", 10461
        } );
