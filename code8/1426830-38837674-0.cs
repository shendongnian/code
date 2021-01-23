      using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace ConsoleApplication6
        {
            class Program
            {
                static void Main(string[] args)
                {
                    ClientPeer clientPeer = new ClientPeer();
                    clientPeer.MyProperty = 5;
                    ConnectedClientList.AddClientPeerToConnectedList(clientPeer);
                    Console.WriteLine(ConnectedClientList.ConnectedClientPeers.Count.ToString());
        
                    ConnectedClientList.AddClientPeerToConnectedList(clientPeer);
                    Console.WriteLine(ConnectedClientList.ConnectedClientPeers.Count.ToString());
        
        
                    clientPeer = new ClientPeer();
                    ConnectedClientList.AddClientPeerToConnectedList(clientPeer);
                    Console.WriteLine(ConnectedClientList.ConnectedClientPeers.Count.ToString());
        
                }
        
                public class ClientPeer
                {
        
                    public int MyProperty { get; set; }
        
                }
        
                public static class ConnectedClientList
                {
                    static readonly object _lock = new object();
                    public static IList<ClientPeer> ConnectedClientPeers;
        
                    static ConnectedClientList()
                    {
                        ConnectedClientPeers = new List<ClientPeer>();
                    }
        
        
                    public static IList<ClientPeer> GetClientPeers()
                    {
                        lock (_lock)
                        {
                            return ConnectedClientPeers;
                        }
        
                    }
        
                    public static void AddClientPeerToConnectedList(ClientPeer client)
                    {
                        lock (_lock)
                        {
                            ConnectedClientPeers.Add(client);
                        }
                    }
        
               
                }
            }
        }
