            using (StreamReader reader = new StreamReader("*** your filepath ***"))
            {
                while (!reader.EndOfStream)
                {
                    double lat = double.Parse(reader.ReadLine());
                    double lon = double.Parse(reader.ReadLine());
                    pin.Location = new Location(lat, lon);
                }
            }
