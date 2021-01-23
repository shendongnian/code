        private void Login_Load(object sender, EventArgs e)
        {
            Stream s2 = File.Open("test.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Person> pList2 = (List<Person>)bf.Deserialize(s2); //Deserialize here no need to set to a new list first.
            //Loop not required for Deserialize as it was stored as a list at this point all people will be available
            //foreach (Person p in pList2)
            //{
                
            //}
            s2.Close();
        }
