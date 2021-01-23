            string fileContent = System.IO.File.ReadAllText("YOUR_FILE_PATH");
            //assumeing each customer record will be on separate line
            string[] lines = fileContent.Split(new string [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                //assuming a single line content will be like this "name,surname,phone,address"
                string[] items = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                Customer cust = new Customer();
                cust.Name = items[0];
                cust.Surname = items[1];
                cust.Phone = items[2];
                cust.Address = items[3];
                //now use this 'cust' object
            }
