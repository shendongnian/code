    using(MemoryStream ms = MethodA(bundleStream)) // dispose of ms after you are done with it
    {
      ms.Position = 0; // reset position
      ms.CopyTo(Context.Response.Body); // write to output stream (assuming .Body is a Stream)
      Context.Response.Body.Flush(); // flush response obj
    }
    Context.Response.End(); // end the response
