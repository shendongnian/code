            // For Receiving Text from the Client
            byte[] responseByteArray = new byte[socket.ReceiveBufferSize]; // 
    //This will create a byte array to store the data. socket.ReceiveBufferSize 
    //will tells us the length of the data sent in byte array (not string yet)
            int responseLength = socket.Receive(responseByteArray);  // Tells us 
    //the length of the response in byte array (not string yet)
            string response = null; // We will create a variable 'response' to 
    //store the final result of the conversion
            for (int i = 0; i < responseLength; i++) // Loop to convert All byte 
    //from byte array to string
            {
                response = response + (char)responseByteArray[i]; // Converts 
    //every single byte of character to char
            }
            Console.WriteLine(response); // Prints out the final result in 
    //string
___
