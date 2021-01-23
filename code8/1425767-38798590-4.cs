    namespace MyTypes
    {
        public class Types
        {
            public struct stats
            {
                float str;
                float con;
                float xxx;
            }
    
            public struct skill
            {
                float mining;
            }
        }
    }
    .....
    using MyTypes;
    namespace MyNPC
    {
        public class NPC
        {
            Types.stats baseStats;
            Types.skill skills;
            string name;
            float hunger;
            float necessity;
            short hp;
        }
    }
