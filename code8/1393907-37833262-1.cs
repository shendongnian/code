    public class Character
        {
            [Key]
            public int CharacterID { get; set; }
            [Column("name")]
            public string name { get; set; }
            [Column("maxLife")]
            protected int maxHitPoint{ get; set; }
            [Column("actualLife")]
            protected int actualHitPoint{ get; set; }
            [Column("baseAgility")]
            protected int baseAgility{ get; set; }
        }
    public class Hero : Character
        {
            [ForeignKey("weaponHolder")]
            public int WeaponHolderID { get; set; }
            [ForeignKey("backPack")]
            public int BackPackID { get; set; }
            [Column("Gold")]
            private int gold{ get; set; }
            public WeaponHolder weaponHolder{ get; set; }
            public List<SpecialItem> specialItems{ get; set; }
        }
