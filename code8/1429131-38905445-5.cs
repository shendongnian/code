    using System.IO;
    using Newtonsoft.Json;
    OnClickEvent
    {
        Entity ent = new Entity();
        string content = string.Empty;
            var localFolder = ApplicationData.Current.LocalFolder;
            await localFolder.CreateFileAsync("test.txt", CreationCollisionOption.OpenIfExists);
            var stream = await localFolder.OpenStreamForReadAsync("test.txt");
            using (StreamReader reader = new StreamReader(stream))
            {
                content = await reader.ReadToEndAsync();
                ent= JsonConvert.DeserializeObject<Entity>(content);
            }
    }
