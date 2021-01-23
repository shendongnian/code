        public class ClientListResponse
        {
            public Dictionary<string, Client> clientList { get; set; }
        }
    Having done so, in theory the JSON you show should now be successfully deserialized, with the dictionary keys being the `Gfjy654-hfGfgv` strings - except that the following issue prevents this from working.
