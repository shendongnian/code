    public static void Main() {
                TcpListener serverSocket = new TcpListener(9999);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;
                serverSocket.Start();
                Console.WriteLine(" >> " + "Server Started");
                counter = 0;
                while (true) {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                    handleClient client = new handleClient();
                    client.startClient(clientSocket, Convert.ToString(counter));
                }
    
                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine(" >> " + "exit");
                Console.ReadLine();
            }
        }
    
        public class handleClient {
    //yourcodehere
    }
