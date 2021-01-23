        public void GetHeader(StringBuilder Builder)
        {
            if (string.IsNullOrEmpty(ContentId) && string.IsNullOrEmpty(ContentType) && string.IsNullOrEmpty(TransferEncoding))
                return;
            if (!string.IsNullOrEmpty(ContentTypeStart))
            {
                Builder.Append(string.Format("Content-Type: {0}", ContentTypeStart));
                Builder.Append(string.Format("; type=\"{0}\"", ContentType));
            }
            else
                Builder.Append(string.Format("Content-Type: {0}", ContentType));
            if (!string.IsNullOrEmpty(CharSet)) Builder.Append(string.Format("; charset={0}", CharSet));
            Builder.Append(new char[] { '\r', '\n' });
            Builder.Append(string.Format("Content-Transfer-Encoding: {0}", TransferEncoding));
            Builder.Append(new char[] { '\r', '\n' });
            Builder.Append(string.Format("Content-Id: {0}", ContentId));
            Builder.Append(new char[] { '\r', '\n' });
            if (!string.IsNullOrEmpty(ContentDisposition))
                Builder.Append(string.Format("Content-Disposition: attachment; filename=\"{0}\"", ContentDisposition));
        }
