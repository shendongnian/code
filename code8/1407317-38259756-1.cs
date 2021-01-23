    using UnityEngine;
    using System.Collections;
    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    public class LatencyTest : MonoBehaviour {
	
	// Use this for initialization
	public void Update () {
		
		// Get coordinates
		double x = transform.position.x;
		
		// Create byte array for sending
		byte[] coordinates = BitConverter.GetBytes(x);
		
		// Define IP Address and Port
		string IP = "127.0.0.1";
		int port= 16;
		Socket client;
		IPEndPoint Dymola;
		//Send to IP Address on the port specified above
		Dymola = new IPEndPoint(IPAddress.Parse (IP), port);
		client = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		client.SendTo (coordinates, Dymola);
		//print (coordinates);
	}
    }
