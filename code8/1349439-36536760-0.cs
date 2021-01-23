    public class Dataservice
    {
        public static void RebuildLibrary()
        {
            string counter = "Files added: 0";
            int i;
            //getting fileList
            foreach (var file in fileList)
            {
                //doing some stuff here
                i++;
                counter = $"Files added: {i}";
                Messenger.Default.Send(new NotificationMessage<string>(counter, "Counter"));
            }
        }
    }
