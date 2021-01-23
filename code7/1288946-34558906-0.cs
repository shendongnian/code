    public class Ans34558541
    {
        public StorageFile XMLFile { get; private set; }
        public XDocument Files { get; private set; }
        private async void AskUserForFile()
        {
            var FilePicker = new Windows.Storage.Pickers.FileOpenPicker();
            FilePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            FilePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            FilePicker.FileTypeFilter.Add(".pcs");
            FilePicker.FileTypeFilter.Add(".pcp");
            XMLFile = await FilePicker.PickSingleFileAsync();
            Action Act = new Action(ParseXML);
            Task Tsk = new Task(Act);
            Tsk.Start();
            Tsk.Wait();
        }
        private void ParseXML()
        {
            Files = XDocument.Load(XMLFile.Path);
        }
    }
