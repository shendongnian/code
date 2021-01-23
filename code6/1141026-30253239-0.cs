    public class Quest
    {
        private List<Quest> quests = new List<Quest>();
        // you need a validation in setter.
        public bool Complete { get; set; }
        public bool CanStart()
        {
            return quests.All(o => o.Complete);
        }
        public void Add(Quest quest)
        {
            this.quests.Add(quest);
        }
        public void Remove(Quest quest)
        {
            this.quests.Remove(quest);
        }
    }
