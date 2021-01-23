    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
    public class Player_Paint : NetworkBehaviour {
	    private int range = 200;
	    [SerializeField] private Transform camTransform;
	    private RaycastHit hit;
	    [SyncVar] private Color objectColor;
	    [SyncVar] private GameObject objectID;
	    private NetworkIdentity objNetId;
	
	    void Update () {
            // only do something if it is the local player doing it
            // so if player 1 does something, it will only be done on player 1's computer
            // but the networking scripts will make sure everyone else sees it
	    	if (isLocalPlayer) {
			    CheckIfPainting ();
		    }
	    }
	    void CheckIfPainting(){
            // yes, isLocalPlayer is redundant here, because that is already checked before this function is called
            // if it's the local player and their mouse is down, then they are "painting"
		    if(isLocalPlayer && Input.GetMouseButtonDown(0)) {
                // here is the actual "painting" code
                // "paint" if the Raycast hits something in it's range
			    if (Physics.Raycast (camTransform.TransformPoint (0, 0, 0.5f), camTransform.forward, out hit, range)) {
				    objectID = GameObject.Find (hit.transform.name);									// this gets the object that is hit
				    objectColor = new Color(Random.value, Random.value, Random.value, Random.value);    // I select the color here before doing anything else
				    CmdPaint(objectID, objectColor);    // carry out the "painting" command
			    }
		    }
	    }
	
	    [ClientRpc]
	    void RpcPaint(GameObject obj, Color col){
		    obj.GetComponent<Renderer>().material.color = col;		// this is the line that actually makes the change in color happen
	    }
	
	    [Command]
	    void CmdPaint(GameObject obj, Color col) {
		    objNetId = obj.GetComponent<NetworkIdentity> ();		// get the object's network ID
		    objNetId.AssignClientAuthority (connectionToClient);	// assign authority to the player who is changing the color
		    RpcPaint (obj, col);									// usse a Client RPC function to "paint" the object on all clients
		    objNetId.RemoveClientAuthority (connectionToClient);	// remove the authority from the player who changed the color
	    }
    }
