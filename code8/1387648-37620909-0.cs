    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    class Program
    {
        private const int sendPort = 9999;
        static void Main(string[] args)
        {
            Boolean done = false;
            IPAddress send_to_address = IPAddress.Parse("10.128.105.177");
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, sendPort);
            EndPoint receiving_end_point = new IPEndPoint(IPAddress.Any, 0);
        while (!done)
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Console.WriteLine("Enter text to send");
            string text_to_send = Console.ReadLine();
            // the socket object must have an array of bytes to send.
            // this loads the string entered by the user into an array of bytes.
            byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
            // Remind the user of where this is going.
            Console.WriteLine("sending to address: {0} port: {1}", sending_end_point.Address, sending_end_point.Port);
            sending_socket.SendTo(send_buffer, sending_end_point);
            Console.WriteLine("Message has been sent to the broadcast address");
            Console.WriteLine("Now we are waiting for a message back from the Listener");
            Byte[] ByteFromListener = new byte[8000];
            sending_socket.ReceiveFrom(ByteFromListener, ref receiving_end_point);
            string datafromreceiver;
            datafromreceiver = Encoding.ASCII.GetString(ByteFromListener).TrimEnd('\0');          
            //Here we print the message from the server
            Console.WriteLine(datafromreceiver.ToString());
           
     
                
            }
            
        }
    }
}
