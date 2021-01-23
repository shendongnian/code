    public class Service
    {
        public class Service() { }
        public void UpdateLastAccessedTimestamp(Entry entry)
        {
            entry.LastAccessedOn = SystemTime.Now();
            this._unitOfWork.Entries.Update(entry);
            this._unitOfWork.Save();
        }
    }
