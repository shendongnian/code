    // Converts the string using the default character encoding
    // (equivalent of Encoding.Default in C#).
    byte[] bytes = text.getBytes();
    // Converts the string using the given character encoding, in this case UTF-8.
    byte[] bytes = text.getBytes("UTF-8");
    // Converts a byte array to a string using the default encoding.
    String text = new String(bytes);
    // Converts a byte array to a string using the given encoding.
    String text = new String(bytes, "UTF-8");
