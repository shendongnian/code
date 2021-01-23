        private void addEntry(GiveawayEntry newEntry)
        {
            GiveawayEntry[] newEntries = new GiveawayEntry[entries.Length + 1];
            Array.Copy(entries, newEntries, entries.Length);
            entries = newEntries;
            for (int i = 0; i < entries.Length; i++)
            {
                Console.WriteLine("Name: " + entries[i].Name + ", Email: " + entries[i].Email);
            }
        }
