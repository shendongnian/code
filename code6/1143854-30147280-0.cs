    using UnityEngine;
    using System.Collections;
    using System.IO.Ports;
    using System.IO;
    
    public class ArduinoCOM : MonoBehaviour
    {
    
    	SerialPort ardPort;
    
    	void Start ()
    	{
    		ardPort = new SerialPort ("COM4", 9600);
    	}
    
    	void Update ()
    	{
    		if (byteIsAvailable ()) {
    			Debug.Log ("Received " + readFromArduino ());
    		}
    	}
    
    	void sendToArduino (string messageToSend)
    	{
    		ardPort.Write (messageToSend + '\n');
    	}
    
    	string readFromArduino ()
    	{
    		string tempReceived = null;
    		
    		if (ardPort.BytesToRead > 0) {
    			tempReceived = ardPort.ReadLine ();
    		}
    		return tempReceived;
    	}
    
    	bool byteIsAvailable ()
    	{
    		if (ardPort.BytesToRead > 0) {
    			return true;
    		} else {
    			return false;
    		}
    	}
    
    }
