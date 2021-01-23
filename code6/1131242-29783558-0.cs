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
            //if some error is caught initializing it to the default constructor instance is a good choice
            temp = new ObservableCollection<int>();
        }
    }
