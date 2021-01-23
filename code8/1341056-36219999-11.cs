    public class Service
    {
        public Service() { }
        public void UpdateLastAccessedTimestamp(Entry entry)
        {
            entry.LastAccessedOn = SystemTime.Now();
            this._unitOfWork.Entries.Update(entry);
            this._unitOfWork.Save();
        }
    }
