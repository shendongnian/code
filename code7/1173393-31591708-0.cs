    // Target endpoint.  Use the default Barix UDP 'high priority'
    // port.
    IPEndPoint target = new IPEndPoint( IPAddress.Parse("192.168.1.100"), 3030 );
    // Create reader...
    NAudio.Wave.Mp3FileReader reader = new Mp3FileReader("hello.mp3");
    // Build a simple udp-socket for sending.
    Socket sender = new Socket( AddressFamily.InterNetwork,
                                SocketType.Dgram,
                                ProtocolType.Udp );
    // Now for some 'constants.'
    double ticksperms = (double)Stopwatch.Frequency;
    ticksperms /= 1000.0;
            
    // We manage 'buffering' by just accumulating a linked list of
    // mp3 frame times.  The maximum time is defined by our buffer
    // time.  For this example, use a 2-second 'buffer'.
    // 'framebufferticks' tracks the total time in the buffer.
    double framebuffermaxticks = ticksperms * 2000.0;
    LinkedList<double> framebuffer = new LinkedList<double>();
    double framebufferticks = 0.0f;
    // We'll track the total mp3 time in ticks.  We'll also need a
    // stopwatch for the internal timing.
    double expectedticks = 0.0;
    Stopwatch sw = new Stopwatch();
    long startticks = Stopwatch.GetTimestamp();
    // Now we just read frames until a null is returned.
    int totalbytes = 0;
    Mp3Frame frame;
    while( (frame = reader.ReadNextFrame()) != null )
    {
        // Make sure the frame buffer is valid.  If not, we'll
        // quit sending.
        byte [] rawdata = frame.RawData;
        if( rawdata == null ) break;
        // Send the complete frame.
        totalbytes += rawdata.Length;
        sender.SendTo(rawdata, target);
        // Timing is next.  Get the current total time and calculate
        // this frame.  We'll also need to calculate the delta for
        // later.
        double expectedms = reader.CurrentTime.TotalMilliseconds;
        double newexpectedticks = expectedms * ticksperms;
        double deltaticks = newexpectedticks - expectedticks;
        expectedticks = newexpectedticks;
        // Add the frame time to the list (and adjust the total
        // frame buffer time).  If we haven't exceeded our buffer
        // time, then just go get the next packet.
        framebuffer.AddLast(deltaticks);
        framebufferticks += deltaticks;
        if( framebufferticks < framebuffermaxticks ) continue;
        // Pop one delay out of the queue and adjust values.
        double framedelayticks = framebuffer.First.Value;
        framebuffer.RemoveFirst();
        framebufferticks -= framedelayticks;
        // Now we just wait....
        double lastelapsed = 0.0f;
        sw.Reset();
        sw.Start();
        while( lastelapsed < framedelayticks )
        {
            // We do short burst delays with Socket.Poll() because it
            // supports a much higher timing precision than
            // Thread.Sleep().
            sender.Poll(100, SelectMode.SelectError);
            lastelapsed = (double)sw.ElapsedTicks;
        }
        // We most likely waited more ticks than we expected.  Timewise,
        // this isn't a lot.  But it could cause accumulate into a large
        // 'drift' if this is a very large file.  We lower the total
        // buffer/queue tick total by the overage.
        if( lastelapsed > framedelayticks )
        {
            framebufferticks -= (lastelapsed - framedelayticks);
        }
    }
    // Done sending the file.  Now we'll just do one final wait to let
    // our 'buffer' empty.  The total time is our frame buffer ticks
    // plus any latency.
    double elapsed = 0.0f;
    sw.Reset();
    sw.Start();
    while( elapsed < framebufferticks )
    {
        sender.Poll(1000, SelectMode.SelectError);
        elapsed = (double)sw.ElapsedTicks;
    }
    // Dump some final timing information:
    double diffticks = (double)(Stopwatch.GetTimestamp() - startticks);
    double diffms = diffticks / ticksperms;
    Console.WriteLine("Sent {0} byte(s) in {1}ms (filetime={2}ms)",
                     totalbytes, diffms, reader.CurrentTime.TotalMilliseconds);
