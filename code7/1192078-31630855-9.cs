    // Write data to general tag memory
    string tagDataStr = "HELLO WORLD!";
    byte[] tagData = ASCIIEncoding.ASCII.GetBytes(tagDataStr);
    byte memBank = 0; // Different memory banks serve different purposes.      See MC9190 specifications.
    int addr = 0;
    byte words = (byte)(tagData.Length / 2); // Words = length of msg / 2
 
    if (UHFWriteTagData(theHandle, readerType, memBank,addr, tagData,     (byte)tagData.Length, out errValue) == 0)
    {
    // Handle Error
    }
 
    // Read data from tag memory
    byte[] readTagData = new byte[512];
    int bytesRead;
 
    if (UHFReadTagData(theHandle, readerType, memBank, addr, words,     readTagData,
    readTagData.Length, out bytesRead, out errValue) == 0)
    {
    // Handle Error
    }
    // Display Results
    string results =
    "Input tag ID: " +
    tagIDStr +
    Environment.NewLine +
    "Read tag ID: " +
    ASCIIEncoding.ASCII.GetString(readTagID).Replace('\0','-') +
    Environment.NewLine +
    "Input tag data: " +
    tagDataStr +
    Environment.NewLine +
    "Read tag data: " +
    ASCIIEncoding.ASCII.GetString(readTagData).Replace('\0', '-').Substring(0,bytesRead) +
    Environment.NewLine;
 
    MessageBox.Show(results);
