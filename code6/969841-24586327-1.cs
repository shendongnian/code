      static void Main(string[] args)
            {
                DateTime  birthDate = new DateTime(1969,12,25);
                int age = (int) ((DateTime.Now - birthDate).TotalDays/365); 
            }
