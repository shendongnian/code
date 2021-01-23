    private void AddPerson(Person person)
    {        
            //save
            var mystream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("file.txt", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(mystream))
            {
                var x = JsonConvert.SerializeObject(person);
                writer.Write(x);
            }
    }
