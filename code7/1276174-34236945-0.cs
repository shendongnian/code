    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
    
    public class OnTouchEvent : NetworkBehaviour
    {
        //this will get called when you click on the gameObject
        [SyncVar]
        public Color cubeColor;
        [SyncVar]
        private GameObject objectID;
        private NetworkIdentity objNetId;
    
    
        void Update()
        {
            if (isLocalPlayer)
            {
                CheckIfClicked();
            }
        }
    
        void CheckIfClicked()
        {
            if (isLocalPlayer && Input.GetMouseButtonDown(0))
            {
                objectID = GameObject.FindGameObjectsWithTag("Tower")[0];                         //get the tower                                   
                cubeColor = new Color(Random.value, Random.value, Random.value, Random.value);    // I select the color here before doing anything else
                CmdChangeColor(objectID, cubeColor);
            }
        }
    
       
    
        [Command]
        void CmdChangeColor(GameObject go, Color c)
        {
            objNetId = go.GetComponent<NetworkIdentity>();        // get the object's network ID
            objNetId.AssignClientAuthority(connectionToClient);    // assign authority to the player who is changing the color
            RpcUpdateCube(go, c);
            // use a Client RPC function to "paint" the object on all clients
            objNetId.RemoveClientAuthority(connectionToClient);    // remove the authority from the player who changed the color
        }
    
        [ClientRpc]
        void RpcUpdateCube(GameObject go, Color c)
        {
            go.GetComponent<Renderer>().material.color = c;
        }
    
    }
