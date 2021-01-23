    I used Using sentence:
    using (Pop3Client client = new Pop3Client())
    			{
    				// conectamos al servidor
    				client.Connect(hostname, port, useSsl);
    
    				// Autentificación
    				client.Authenticate(username, password);
    
    				client.DeleteAllMessages();
    			}
    Work ok in my Proyect
