        private void addgsc()
        {
            string file = modspath + "//maps//_zombiemode_weapons.gsc";
            List<string> lines = new List<string>(System.IO.File.ReadAllLines(file));
            int index = lines.FindLastIndex(item => item.Contains("add_zombie_weapon"));
            if (index != -1)
            {
                lines.Insert(index + 1, "test 21");
            }
            System.IO.File.WriteAllLines(file, lines);
        }
