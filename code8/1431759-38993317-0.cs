     public bool Contains (string searchTerm)
        {
            string line;
            bool found = false;
           
           
                System.IO.StreamReader file = new System.IO.StreamReader("ProductNames.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(searchTerm))
                    {
                        found = true;
                        break;
                    }
                }
            file.Close();
                   
            if (found == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
