    private void SaveData(string fil, List<Animal> animalList)
    {   
        // serialize entire list
        using (FileStream fs = new FileStream(fil, FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, animalList);
        }
    }
    
    private List<Animal> LoadData(string filename)
    {
        List<Animal> newLst = new List<Animal>();
    
        // deserialize entire list and return it
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            newLst= (List<Animal>)bf.Deserialize(fs);
        }
        return newLst;
    }
