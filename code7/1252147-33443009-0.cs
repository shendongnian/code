    SortedList<int, bool> roomsList = new SortedList<int, bool>();
    using (StreamReader reader = new StreamReader(@"C:\temp\RoomList.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] rooms = line.Split('-');
                    roomsList.Add(int.Parse(rooms[0]), bool.Parse(rooms[1]));
                }
            }
