    public class SoundGroup : List<Group<SoundData>>
    {
        public string Title { get; set; }
        public SoundGroup() {}
        public SoundGroup(SaveSoundGroup data) : base(data.GroupBy(item => item.Groups).Select(grp => new Group<SoundData>(grp.Key, grp.ToList())))
        {
            this.Title = data.Title;
        }
    }
    public class SaveSoundGroup : List<SoundData>
    {
        public string Title { get; set; }
        public SaveSoundGroup()
        {
            this.Title = string.Empty;
        }
        public SaveSoundGroup(SoundGroup data)
		: base()
		{
			this.Title = data.Title;
			foreach(var grp in data)
				this.AddRange(grp);
		}
    }
