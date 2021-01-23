    for (int i = 0; i < bytes; i++)
    {
        temp[i] = buffer[i];
    }
         
    bufferString = System.Text.Encoding.ASCII.GetString(temp);
