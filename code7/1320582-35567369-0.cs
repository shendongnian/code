    using(MemoryStream ms = MethodA(bundleStream)) // dispose of ms after you are done with it
    {
      ms.Position = 0; // reset position
      ms.CopyTo(Context.Response.OutputStream); // write to output stream
      Context.Response.OutputStream.Flush(); // flush response obj
    }
    Context.Response.End(); // end the response
