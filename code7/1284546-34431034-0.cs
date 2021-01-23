     Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
    
                byte[] b = new byte[100];
                int k = s.Receive(b);
    
                Console.WriteLine("Recieved...");
    
                a = f.BeginWrite(b, 0, b.Length, null, null);
                f.EndWrite(a);
    
                String[] str = Encoding.UTF8.GetString(b).Split('|');
                for (int i = 0; i < str.Length; i++)
                    Console.WriteLine(str[i]);
    
                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
    
                //s.Close();
                myList.Stop();
