    public static readonly Item MagicSword = new Item
    {
        ItemQuality = ItemQuality.Rare,
        Cost = 5000,
        Features = new List<IFeature>
        {
            new Weapon { Damage = 10 },
            new MagicItem { Spell = Spells.TurnToFrog }
        }
    }
