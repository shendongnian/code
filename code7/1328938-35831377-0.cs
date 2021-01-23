    public bool ReadFromBin(string a, string b)
        {
            bool okFlag = false;
            FileStream fileStream = File.OpenRead("../../TextFiles/users.bin");
            BinaryReader binaryReader = new BinaryReader(fileStream);
            while (binaryReader.PeekChar() != -1)
            {
                newUser.Forename = binaryReader.ReadString();
                newUser.Surname = binaryReader.ReadString();
                newUser.Username = binaryReader.ReadString();
                newUser.Password = binaryReader.ReadString();
                if ((newUser.Username == a) && (newUser.Password == b))
                  {
                     okFlag = true;
                     break;
                  }
            }
            binaryReader.Close();
            return okFlag;
        }
