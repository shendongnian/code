    while ((
             i = stream.Read(bytesIn, 0, bytesIn.Length)) != 0    //read the contents of the 
                                                                  //stream and put it in 
                                                                  //bytesIn, if available 
                                                                )
    {
        var received = new byte[i];              //Create a new, empty array, which we are 
                                                 //going to put in the queue.
        Array.Copy(bytesIn, 0, received, 0, i);  //Copy the contents of bytesIn into our new
                                                 //array. This way we can reuse bytesIn while
                                                 //maintaining the received data.
        fifo.Enqueue(received);                  //Enqueue the new array and thus saving it.
    } 
