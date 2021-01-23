    private string generateUniqueID(int size) //recieves the size of the wanted hex ID
    {
        bool done = true;
        string n_id = "";
        
        while (!done)
        {
            done = true;
            while (n_id.Length < size + 1)
                n_id += Char.ConvertFromUtf32(new Random().Next(48, 90));
            foreach (Transaction i in tns) //I used this for each to check if the generated ID already exists, you can use an external function.
            {
                if (i.ID == n_id)
                {
                    done = false;
                    break;
                }
            }
        }
        return n_id;
    }
