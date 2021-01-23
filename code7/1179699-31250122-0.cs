    public class ClipBoardBackupRestore
    {
        Dictionary<string, object> clipboardContents = new Dictionary<string, object>();
        public void Backup()
        {
            clipboardContents.Clear();
            IDataObject clipboardDataObject = Clipboard.GetDataObject();
            foreach (string format in clipboardDataObject.GetFormats())
            {
                clipboardContents.Add(format, clipboardDataObject.GetData(format));
            }
        }
        public void Restore()
        {
            DataObject clipboardDataObject = new DataObject();
            foreach (string format in clipboardContents.Keys)
            {
                clipboardDataObject.SetData(format, clipboardContents[format]);
            }
            Clipboard.SetDataObject(clipboardDataObject);
        }
    }
