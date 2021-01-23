             ComputerGame[] gameAlbum = new ComputerGame[5];
            gameAlbum[0] = new ComputerGame("Age of Empires", 49.99);
            gameAlbum[1] = new ComputerGame("Heroes and Generals", 30.00);
            gameAlbum[2] = new ComputerGame("Team Fortress 2", 19.50);
            gameAlbum[3] = new ComputerGame("Portal", 19.50);
            gameAlbum[4] = new ComputerGame("Portal 2", 29.50);
            //looping the data
            foreach (ComputerGame item in gameAlbum)
            {
                if (item != null)
                    Response.Write("Name : " + item.title + " Price : " + item.price);
            }
            //get the sum of the price
            double total = gameAlbum.Sum(p => p.price);
            Response.Write(total);
