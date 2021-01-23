    private static async Task<String> IssueClientRequestAsync(String serverName, String message) { 
       using (var pipe = new NamedPipeClientStream(serverName, "PipeName", PipeDirection.InOut,  
          PipeOptions.Asynchronous | PipeOptions.WriteThrough)) { 
          pipe.Connect(); // Must Connect before setting ReadMode 
          pipe.ReadMode = PipeTransmissionMode.Message; 
          // Asynchronously send data to the server 
          Byte[] request = Encoding.UTF8.GetBytes(message); 
          await pipe.WriteAsync(request, 0, request.Length); 
          // Asynchronously read the server's response 
          Byte[] response = new Byte[1000]; 
          Int32 bytesRead = await pipe.ReadAsync(response, 0, response.Length); 
          return Encoding.UTF8.GetString(response, 0, bytesRead); 
       }  // Close the pipe 
    } 
