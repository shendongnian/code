    private byte[] GetEmbeddedResourceBytes(string resource)
    {
        var asm = Assembly.GetExecutingAssembly();
        using (var stream = asm.GetManifestResourceStream(resource)) {
            if (stream != null) {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream()) {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
        }
        return new byte[0];
    }
