    using System.IO
    OnClickEvent()
    {
        Entity ent = new Entity();
        ent.name = tbxName.Text;
        ent.age = int.Parse(tbxAge.Text);
        ent.dinner = tbxDinner.Text;
        //save
            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("[PUT-HERE-NAME].txt", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(myStream))
            {
                var results = JsonConvert.SerializeObject(ent);
                writer.Write(results);
            }
    }
