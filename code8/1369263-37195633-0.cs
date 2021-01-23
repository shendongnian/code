            if ((previousChar == null) && (bytesRead == 1))
            {
                previousChar = Encoding.ASCII.GetString(readBuffer, 0, bytesRead);
            }
            // Convert the byte array the message was saved into
            if (bytesRead > 6)
            {
                message = Encoding.ASCII.GetString(readBuffer, 0, bytesRead);
                if (previousChar != null)
                {
                    message = previousChar + message;
                    previousChar = null;
                }
