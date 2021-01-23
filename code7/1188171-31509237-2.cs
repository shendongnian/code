    
    
    NetworkStream ns = client.GetStream();
    ...
    string[] tokens = request.Split(' ');
    string page = tokens[1];
    if (page == "/")
    {
        page = "/default.htm";
    }
    //StreamReader file = new StreamReader("../../web" + page);
    byte[] file = null;
    try { file = File.ReadAllBytes(@"../../web" + page); }
    // In this 'catch' block, you can't read requested file.
    catch {
        // do something (like printing error message)
    }
    // We are not going to use StreamWriter, we'll use StringBuilder
    StringBuilder sbHeader = new StringBuilder();
    // STATUS CODE
    sbHeader.AppendLine("HTTP/1.1 200 OK");
    // CONTENT-LENGTH
    sbHeader.AppendLine("Content-Length: " + file.Length);
    // Append one more line breaks to seperate header and content.
    sbHeader.AppendLine();
    // List for join two byte arrays.
    List<byte> response = new List<byte>();
    // First, add header.
    response.AddRange(Encoding.ASCII.GetBytes(sbHeader.ToString()));
    // Last, add content.
    response.AddRange(file);
    // Make byte array from List<byte>
    byte[] responseByte = response.ToArray();
    // Send entire response via NetworkStream
    ns.Write(responseByte, 0, responseByte.Length);
