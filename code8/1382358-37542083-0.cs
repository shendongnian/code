            public void fill_tree()
            {
                foreach (localhost.Main_Subjects a in msl)
                {
                    var node0 = treeView1.Nodes.Add(a.name);
                    node0.Tag = a;
                    foreach (localhost.Subject b in sl)
                    {
                        if (b.main_subject_id == a.main_subject_id)
                        {
                            var node1 = node0.Nodes.Add(b.name);
                            node1.Tag = b;
    
                            foreach (localhost.Mini_subjects c in mnsl)
                            {
                                if (c.subject_id == b.subjects_id)
                                {
                                    var node2 = node1.Nodes.Add(c.name);
                                    node2.Tag = c;
    
                                    foreach (localhost.Text d in tl)
                                    {
                                        if (d.mini_subjects_id == c.mini_subjects_id)
                                        {
                                            var node3 = node2.Nodes.Add(d.name);
                                            node3.Tag = d;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
