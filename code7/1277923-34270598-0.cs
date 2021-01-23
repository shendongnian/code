    using (FileStream LocalStream = new FileStream(TempFileName, FileMode.Create))
                {
                   using (var transaction = Conn.BeginTransaction())
                   {
                      // create a Large Object Manager for this connection
                      var DbLargeObjectManager = new NpgsqlLargeObjectManager(Conn);
    
                      using (var DbStream = await DbLargeObjectManager.OpenReadAsync(oid))
                      {
                         byte[] buffer = new byte[262144]; //256KB
                         // query the database stream length
                         long DatabaseStreamLength = DbStream.Length;
                         while (DbStream.Position < DatabaseStreamLength)
                         {
                            // read from the database to buffer (async)
                            int bufferByteCount = await DbStream.ReadAsync(buffer, 0, buffer.Length);
                            //write from buffer to local file (sync)
                            LocalStream.Write(buffer, 0, bufferByteCount);
                         }
                      }
                      transaction.Commit();
