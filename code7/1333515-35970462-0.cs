            string myfile = "";
            var cars = new HashSet<string>();
            var cams_input = new HashSet<string>();
            var result = new Dictionary<string, int>();
            foreach (var line in System.IO.File.ReadLines(myfile, System.Text.Encoding.UTF8))
            {
                var everyItem = line.Split('|'); //line sample: jdsga237 | 3332, 3223, 121 |
                var car = everyItem[0];
                if (cars.Contains(car)) continue;
                var cameras = everyItem[1].Split(',');
                for (int camera = 0; camera < cameras.Length; camera++)
                {
                    if (cams_input.Contains(cameras[camera]))
                    {
                        cars.Add(car);
                        // I really don't get who is inserting value zero.
                        result[myfile]++;
                    }
                }
            }
