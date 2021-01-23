    string Replace(string s,List<string> list,List<Models.SpellVarsDto> vars) {
            for (int i = 0; i < list.Count; i++)
            {
                string s1 = "{{ e" + i.ToString() + " }}";
                if (s.Contains(s1))
                {
                    string s2 = s.Substring(s.IndexOf(s1), s1.Length);
                    s = s.Replace(s1, list[i]);
                    spellDesc.Text = s;
                    //MessageBox.Show(s + " " + s1 + " " + list[i]);
                }
                string s3 = "{{ a" + i.ToString() + " }}";
                if (s.Contains(s3))
                {
                    foreach (Models.SpellVarsDto item in vars)
                    {
                        if (item.key == "a" + i.ToString())
                        {
                            string s4 = s.Substring(s.IndexOf(s3), s3.Length);
                            s = s.Replace(s3, item.coeff[0].ToString());
                            spellDesc.Text = s;
                        }
                    }
                    
                }
            }
            return null;
        }
