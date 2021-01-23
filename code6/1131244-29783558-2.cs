    using System.Collections.ObjectModel;
    using System.Runtime.Serialization.Json;
    using Windows.Storage;
    //Add your own generic implementation of the collection
    //and make changes accordingly
    private ObservableCollection<int> temp;
    private string file = "temp.json";
    private async void saveToFile()
    {
        //add your items to the collection
        temp = new ObservableCollection<int>();
        var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<int>));
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(file, CreationCollisionOption.ReplaceExisting))
        {
            jsonSerializer.WriteObject(stream, temp);
        }
    }
    private async Task getFormFile()
    {
        var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<int>));
        try
        {
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(file))
            {
                temp = (ObservableCollection<int>)jsonSerializer.ReadObject(stream);
            }
        }
        catch
        {
            //if some error is caught while reading data from the file then initializing 
            //the collection to default constructor instance is a good choice 
            //again it's your choice and may differ in your scenario
            temp = new ObservableCollection<int>();
        }
    }
