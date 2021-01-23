    public interface ISomething
    {
        public DateTime DCDTime { get; set; }
        public DateTime LastModDTime { get; set; }
        public int ID { get; set; }
        public DateTime ScanDateTime { get; set; }
        public int SrNo { get; set; }
    }
        private IEnumerable<T> GetSoftwareEntityData<T>(Information request, DateTime scanDateTime, Func<Information, T> someCollection)
        where T : ISomething
       {
        int SrNo = 0;
        foreach (var item in someCollection(request))
        {
            item.DCDTime = DateTime.Now;
            item.LastModDTime = scanDateTime;
            item.ID = request.Id;
            item.ScanDateTime = scanDateTime;
            item.SrNo = ++SrNo;
            yield return item;
        }
    }
