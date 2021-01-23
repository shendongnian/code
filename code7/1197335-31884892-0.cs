    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public static void invia(byte[] bytetosend)
            {
                // Data buffer for incoming data.
                byte[] bytes = new byte[1024];
                // Connect to a remote device.
                try
                {
                    // Establish the remote endpoint for the socket.
                    // This example uses port 11000 on the local computer.
                    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
                    // Create a TCP/IP  socket.
                    Socket sender = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);
                    // Connect the socket to the remote endpoint. Catch any errors.
                    try
                    {
                        sender.Connect(remoteEP);
                        Console.WriteLine("Socket connected to {0}",
                            sender.RemoteEndPoint.ToString());
                        // Encode the data string into a byte array.
                        var mahByteArray = new List<byte>();
                        mahByteArray.AddRange(bytetosend);
                        string eof = "<EOF>";
                        mahByteArray.Insert(0, Convert.ToByte(eof)); // Adds eof bytes to the beginning.
                        byte[] msg = mahByteArray.ToArray();
                        // Send the data through the socket.
                        int bytesSent = sender.Send(msg);
                        // Receive the response from the remote device.
                        int bytesRec = sender.Receive(bytes);
                        Console.WriteLine("Echoed test = {0}",
                            Encoding.ASCII.GetString(bytes, 0, bytesRec));
                        // Release the socket.
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            public void ricevi()
            {
                // Data buffer for incoming data.
                List<byte> bytes = (new Byte[1024]).ToList();
                List<byte> scambioArray = new List<byte>();
                // Establish the local endpoint for the socket.
                // Dns.GetHostName returns the name of the 
                // host running the application.
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                // Bind the socket to the local endpoint and 
                // listen for incoming connections.
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    // Start listening for connections.
                    while (true)
                    {
                        Console.WriteLine("Waiting for a connection...");
                        // Program is suspended while waiting for an incoming connection.
                        Socket handler = listener.Accept();
                        string eofr = "<EOF>";
                        List<byte> trova = Encoding.UTF8.GetBytes(eofr).ToList();
                        // An incoming connection needs to be processed.
                        while (true)
                        {
                            bytes = (new byte[1024]).ToList();
                            int bytesRec = handler.Receive(bytes.ToArray());
                           
                            if (bytes.Contains(trova[0]))
                            {
                                List<byte> mahByteArray = new List<byte>();
                                mahByteArray.AddRange(bytes);
                                mahByteArray.Remove(trova[0]);
                                bytes = mahByteArray.ToArray().ToList();
                                break;
                            }
                            scambioArray.AddRange(bytes);
                        }
                        // Echo the data back to the client.
                        byte[] msg = scambioArray.ToArray();
                        MemoryStream stream = new MemoryStream(msg);    
                        MessageData.Image = Image.FromStream(stream);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
    ​
