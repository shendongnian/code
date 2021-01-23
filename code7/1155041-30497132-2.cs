    Dictionary<Skill, object> dic = new Dictionary<Skill, object>();
                for (int i = 0; i < 5; i++)
                {
                    dic.Add(new Skill() { SkillName = i.ToString() }, new object());
                }
    
                Skill lookup = dic.Keys.FirstOrDefault(sk => sk.SkillName == "0");
    
                Console.WriteLine(dic.ContainsKey(lookup));
