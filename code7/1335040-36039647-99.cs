               Builder.Append(string.Format("Content-Type: {0}", item.ContentType));
                if (!string.IsNullOrEmpty(item.CharSet)) Builder.Append(string.Format("; charset={0}", item.CharSet));
                Builder.Append(new char[] { '\r', '\n' });
                Builder.Append(string.Format("Content-Transfer-Encoding: {0}", item.TransferEncoding));
                Builder.Append(new char[] { '\r', '\n' });
                Builder.Append(string.Format("Content-Id: {0}", item.ContentId));
