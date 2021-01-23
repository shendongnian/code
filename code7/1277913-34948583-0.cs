    public class CharacterMapping : ClassMap<Character>
    {
        public CharacterMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ApplicationUser).Cascade.All();
        }
    }
