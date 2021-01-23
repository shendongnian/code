    namespace SpecialFactory
    {
        public enum ItemType
        {
            Item1,
            Item2,
            // ... Anyone deriving the Item* should add an item here
        }
        public abstract class ItemBase
        {
            public abstract ItemType Id {get;}
            public static void RegisterAllCreators()
            {
                // Force static constructors invocation
                var it = Item1.ClassId | Item2.ClassId; // Anyone deriving the Item* should ensure invocation of Manager.RegisterCreator
            }
        }
        public class Item1 : ItemBase
        {
            static Item1()
            {
                Manager.RegisterCreator(ItemType.Item1, () => new Item1());
            }
            protected Item1()
            {
            }
            public static   ItemType ClassId => ItemType.Item1;
            public override ItemType Id      => ClassId;
        }
        public class Item2 : ItemBase
        {
            static Item2()
            {
                Manager.RegisterCreator(ItemType.Item2, () => new Item2());
            }
            protected Item2()
            {
            }
            public static   ItemType ClassId => ItemType.Item2;
            public override ItemType Id      => ClassId;
        }
    }
