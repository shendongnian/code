        public static IObservable<DataMessage> Convert(IObservable<ArraySegment<byte>> bytes)
                {
                    const int headerSize = 12; // bytes
                    return bytes.Scan(
                        new
                        {
                            Leftovers = new byte[0],
                            Messages = new List<DataMessage>(),
                            Header = (Header) null
                        },
                        (saved, current) =>
                        {
                            var data = ConcatdArrays(saved.Leftovers, current.ToArray());
                            var messages = new List<DataMessage>();
                            var header = saved.Header;
                            while (true)
                            {
                                // Header
                                if (header == null && data.Count >= headerSize)
                                {
                                    header = ReadHeader(ref data, headerSize);
                                }
                                // Payload
                                else if (header != null)
                                {
                                    var type = header.Type;
                                    var size = DataItem.Size(type);
                                    if (data.Count < size) break; // Still missing data
                                    // Create new message with the gathered data
                                    var payload = ReadPayload(ref data, size);
                                    messages.Add(new DataMessage(header, payload));
                                    header = null;
                                }
                                // Can't do more with the available data - try again next round.
                                else
                                {
                                    break;
                                }
                            }
                            return new
                            {
                                Leftovers = data.ToArray(),
                                Messages = messages,
                                Header = header
                            };
                        }).SelectMany(list => list.Messages);
