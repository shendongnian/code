    class MessageReader {
        static readonly Dictionary<byte, Type> _typesMap = new Dictionary<byte, Type>(); 
        static MessageReader() {
            // initialize your map
            // this is executed only once per lifetime of your app
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(c => c.GetCustomAttribute<MessageAttribute>() != null)) {
                var message = type.GetCustomAttribute<MessageAttribute>();
                _typesMap.Add((byte)message.Type, type);
            }
        }
        public async Task<object> Read(Stream stream) {
            // this is your network or any other stream you have
            // read first byte - that is message type
            var firstBuf = new byte[1];
            if (await stream.ReadAsync(firstBuf, 0, 1) != 1) {
                // failed to read - end of stream
                return null;
            }
            var type = firstBuf[0];
            if (!_typesMap.ContainsKey(type)) {
                // unknown message, handle somehow
                return null;
            }
            // read next 4 bytes - length of a message
            var lengthBuf = new byte[4];
            if (await stream.ReadAsync(lengthBuf, 0, 4) != 4) {
                // read less than expected - EOF
                return null;
            }
            var length = BitConverter.ToInt32(lengthBuf, 0);
            // check if length is not too big here! or use 2 bytes for length if your messages allow that
            if (length > 1*1024*1024) {
                // for example - adjust to your needs
                return null;
            }
            var messageBuf = new byte[length];
            if (await stream.ReadAsync(messageBuf, 0, length) != length) {
                // didn't read full message - EOF
                return null;
            }
            try {
                return ProtoBuf.Serializer.NonGeneric.Deserialize(_typesMap[type], new MemoryStream(messageBuf));
            }
            catch {
                // handle invalid message somehow
                return null;
            }
        }
    }
