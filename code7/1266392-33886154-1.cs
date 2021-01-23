            {
                Room r = new Room();
                string[] splitters = new string[] { @" " };
                r.RoomLevel = node.InnerText.Split(splitters, StringSplitOptions.None)[3];
                r.RoomType = node.InnerText.Split(splitters, StringSplitOptions.None)[5];
                roomList.Add(r);
            }
