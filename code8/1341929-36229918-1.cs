    foreach (var attachment in message.Attachments) {
        using (var stream = File.Create ("fileName")) {
            if (attachment is MessagePart) {
                var part = (MessagePart) attachment;
                part.Message.WriteTo (stream);
            } else {
                var part = (MimePart) attachment;
                part.Content.DecodeTo (stream);
            }
        }
    }
