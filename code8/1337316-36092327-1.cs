    int bytes = stream.Read(bytesFrom, 0, bufferSize);
    if (bytes == 0)
    {
        // client has disconnected
        break;
    }
    dataFromClient = System.Text.Encoding.UTF8.GetString(bytesFrom, 0, bytes);
