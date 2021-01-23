    In & or && Both are doing AND operation but behaviour is very different when you try to compare with'&' then if first is true or not it's doesn't effect on it and always it goes to second statement and set it value like if(a==b & a=b) it's always goes to the second statement but when you use '&&' operator like if(a==b && a=b) in that case if first condition is true hen only give to the second statement .and the same thing happening in your condition also .
    But you can compare bt == BonusType.DestroyWholeRowColumn but because you are comparing enum value which is basically taking int value .if you want to know some more in detail so follow this program do some r&d on it.basically '&' or '|' this operator work on binary format.
     class Program
        {
            static void Main(string[] args)
            {
                BonusType bt=(BonusType)1;
                Console.WriteLine(ContainsDestroyWholeRowColumn(bt));
                Console.ReadLine();
            }
    
            public static bool ContainsDestroyWholeRowColumn(BonusType bt)
            {
                return (bt == BonusType.DestroyWholeRowColumn);
                   // == BonusType.DestroyWholeRowColumn;
            }
        }
    
        [Flags]
        public enum BonusType
        {
            None=1,
            DestroyWholeRowColumn=0,
            abc,
            xyz
        }
    
