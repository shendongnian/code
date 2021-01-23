    public class NetworkPlayerBridge : NetworkBehaviour
    {
        //Call this from your chat window object on the local player
        public void BroadcastChat(string msg)
        {
            CmdBroadcastChat(msg);
        }
        [Command]
        public void CmdBroadcastChat(string msg)
        {
             //send this message to the chat window on the server and place
             //it in a SyncList so that all clients will be updated
        }
    }
