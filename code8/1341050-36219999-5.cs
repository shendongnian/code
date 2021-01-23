        public class Service()
        {
            private readonly IDateTime _iDateTime;
            public class Service(IDateTime iDateTime)
            {
                if (iDateTime == null)
                    throw new ArgumentNullException(nameof(iDateTime));
                // or you could new up the concrete implementation of SystemDateTime if not provided
                _iDateTime = iDateTime;
            }
            public void UpdateLastAccessedTimestamp(Entry entry)
            {
                entry.LastAccessedOn = _iDateTime.Now;
                this._unitOfWork.Entries.Update(entry);
                this._unitOfWork.Save();
            }           
        }
