    var bytes = new byte[]
    {
        210, 240, 224, 237, 231, 224, 234, 246, 232, 255, 32, 237, 229, 32, 236, 238, 230, 229, 242, 32, 225, 251, 242
    };
    var text = System.Text.Encoding.GetEncoding(1251).GetString(bytes);
    // text = "Транзакция не может быт"
