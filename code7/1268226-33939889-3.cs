    static void Main(string[] args)
    {
        int EntriesRead;
        int TotalEntries;
        IntPtr Resume;
        IntPtr bufPtr;
        string groupName = "Administratoren";
        string computerName = null; // null for the local machine
        uint retVal = NetworkAPI.NetLocalGroupGetMembers(computerName, groupName, 1, out bufPtr, -1, out EntriesRead, out TotalEntries, out Resume);
        if(retVal != 0)
        {
            if (retVal == NetworkAPI.ERROR_ACCESS_DENIED) { Console.WriteLine("Access denied"); return; }
            if (retVal == NetworkAPI.ERROR_MORE_DATA) { Console.WriteLine("ERROR_MORE_DATA"); return; }
            if (retVal == NetworkAPI.ERROR_NO_SUCH_ALIAS) { Console.WriteLine("Group not found"); return; }
            if (retVal == NetworkAPI.NERR_InvalidComputer) { Console.WriteLine("Invalid computer name"); return; }
            if (retVal == NetworkAPI.NERR_GroupNotFound) { Console.WriteLine("Group not found"); return; }
            if (retVal == NetworkAPI.SERVER_UNAVAILABLE) { Console.WriteLine("Server unavailable"); return; }
            Console.WriteLine("Unexpected NET_API_STATUS: " + retVal.ToString()); 
            return;
        }
        if (EntriesRead > 0)
        {
            NetworkAPI.LOCALGROUP_MEMBERS_INFO_1[] Members = new NetworkAPI.LOCALGROUP_MEMBERS_INFO_1[EntriesRead];
            IntPtr iter = bufPtr;
            for (int i = 0; i < EntriesRead; i++)
            {
                Members[i] = (NetworkAPI.LOCALGROUP_MEMBERS_INFO_1)Marshal.PtrToStructure(iter, typeof(NetworkAPI.LOCALGROUP_MEMBERS_INFO_1));
                //x64 safe
                iter += Marshal.SizeOf(typeof(NetworkAPI.LOCALGROUP_MEMBERS_INFO_1));
                Console.WriteLine(Members[i].lgrmi1_name);
            }
            NetworkAPI.NetApiBufferFree(bufPtr);
        }
    }
