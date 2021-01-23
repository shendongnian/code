        [Serializable]
        public class SomeType
        {
            public bool isUsed;
        }
    
        public class Data
        {
            //removed because its not permitted here,you already have sometype serializable...
            public List<SomeType> myList = new List<SomeType>(20);
            private string dataPath = "SomePath";
    
            public void Save()
            {
                using (FileStream fs = File.Create(dataPath))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, myList);
    
                }
                //just for testing purposes i cleared the list at this point...
                myList.Clear();
            }
    
            public void Load()
            {
                using (FileStream fs = File.Open(dataPath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    myList = (List<SomeType>)formatter.Deserialize(fs);
                }
            }
        }
