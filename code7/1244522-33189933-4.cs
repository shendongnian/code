    public static void ValidatePhone()
    {
        List<Clients> clients = Program.GetAllClients();
        Regex regex = new Regex(@"Someregex");
        for (int i = 0; i < clients.Count; i++)
        {
            if (!regex.IsMatch(clients[i].Phone))            
                clients[i].Phone = "[Invalid phone number]";
            }
        }
    }
