    while((count = s.Receive(buffer)) != 0)
        {
            // Convert the current buffer to a string (using the number of read bytes as the length of this string)
            string newText = System.Text.Encoding.ASCII.GetString(buffer, 0, count);
           //Console.WriteLine($"New data received: {newText}");
        }
