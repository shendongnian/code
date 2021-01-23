    public static class SftpClientExtensions
    {
        public static void DeleteLink(this SftpClient client, string path)
        {
            Type sftpClientType = client.GetType();
            FieldInfo sftpSessionField = sftpClientType.GetField("_sftpSession", BindingFlags.NonPublic | BindingFlags.Instance);
            object sftpSession = sftpSessionField.GetValue(client);
            Type sftpSessionType = sftpSession.GetType();
            MethodInfo requestRemoveMethod = sftpSessionType.GetMethod("RequestRemove", BindingFlags.NonPublic | BindingFlags.Instance);
            requestRemoveMethod.Invoke(sftpSession, new object[] { path });
        }
    }
