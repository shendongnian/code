        static void Main(string[] args)
        {
            try
            {
                List<FolkbokforingspostTYPE> deserializedList = new List<FolkbokforingspostTYPE>();
                deserializedList = Deserialize<List<FolkbokforingspostTYPE>>();
                var PersonalIdentityNumber = deserializedList.Select(item => item.Personpost.PersonId.PersonNr).ToList();
                foreach(var i in PersonalIdentityNumber)
                {
                    Console.WriteLine("Personnummer: " + i);
                }
            }// Put a break-point here, then mouse-over PersonalIdentityNumber...  deserializedList contains everything if you need it
            catch (Exception)
            {
                throw;
            }
            Console.ReadKey();
        }
