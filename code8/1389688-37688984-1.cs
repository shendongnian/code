        static void Main(string[] args) {
            // original stream
            var stream = new MemoryStream(new byte[] { 0x81, 0x01,0x02,0x03,0x1B,0x1B,0x82,0x82});
            // your initial IObservable<byte[]>
            IObservable<byte[]> bytes = stream.AsyncRead(128); // or any other buffer size
            // your IObservable<Message>
            var observable = Observable.Create<Message>(observer => {
                // some crude parsing code for the sake of example
                bool nextIsEscaped = false;
                bool readingHeader = false;
                bool readingBody = false;
                List<byte> body = new List<byte>();
                List<byte> header = new List<byte>();
                return bytes.Subscribe(buffer => {
                    foreach (var b in buffer) {
                        if (b == 0x81 && !nextIsEscaped && !readingHeader) {
                            // start
                            readingHeader = true;
                            readingBody = false;
                            nextIsEscaped = false;
                        }
                        else if (b == 0x82 && !nextIsEscaped && !readingHeader) {
                            // end
                            readingHeader = false;
                            readingBody = false;
                            if (header.Count > 0 || body.Count > 0) {
                                observer.OnNext(new Message() {
                                    Header = header.ToArray(),
                                    Body = body.ToArray()
                                });
                                header.Clear();
                                body.Clear();
                            }
                            nextIsEscaped = false;
                        }
                        else if (b == 0x1B && !nextIsEscaped && !readingHeader) {
                            nextIsEscaped = true;
                        }
                        else {
                            if (readingHeader) {
                                header.Add(b);
                                if (header.Count == 3) {
                                    readingHeader = false;
                                    readingBody = true;
                                }
                            }
                            else if (readingBody)
                                body.Add(b);
                            nextIsEscaped = false;
                        }
                    }
                });
            });
            observable.Subscribe(msg =>
            {
                Console.WriteLine("Header: " + BitConverter.ToString(msg.Header));
                Console.WriteLine("Body: " + BitConverter.ToString(msg.Body));
            });
            Console.ReadKey();
        }  
