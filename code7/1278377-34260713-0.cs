        public bool aFaerie_Charm()
        {
            var allylist = new List<Obj_AI_Hero>();
            allylist.AddRange(HeroManager.Allies);
            bool z = false;
            for (int i = 0; i < allylist.Count; i++) //allylist.count = 4
            {
                z = Items.HasItem((int)ItemId.Faerie_Charm, allylist[i]);
                //You got 'z' now print  a line
                Console.WriteLine("Ally " + (i + 1) + ": " + z ? ".25" : "false");
            }
            return z;
        }
