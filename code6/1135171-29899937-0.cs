    abstract class Character
    {
        String name
        int hitpoints;
        IList<Item> inventory;
    }
    abstract class Spellcaster : Character
    {
        int manapoints;
        IList<Spell> knownSpells;
    }
    class Mage : Spellcaster
    {
        // Mage specific stuff
    }
    class Necromancer : Spellcaster
    {
        // Necromancer specific stuff
    }
