            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\theReport.csv");
            while ((line = file.ReadLine()) != null)
            {
                var elements = line.Split(' ');
                if (elements[3] == "Something I Am Interested In")
                {
                    //Do Something
                }
            }
