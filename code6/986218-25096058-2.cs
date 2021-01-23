                var filteredMenus = from m in Menucollection
                                    where m.RefCode != "0" || Menucollection.Any(m1=>m1.ParentId == m.Id)
                                    select m;
    
                foreach(var m in filteredMenus)
                {
                    m.ChildMenus = filteredMenus.Where(m1=>m1.ParentId == m.Id).ToList();
                }
    
                var expanded = from m in filteredMenus
                           where m.ParentId == 0
                           select new { Menu = m, Descendants = m.AsBreadthFirstEnumerable(m1 => m1.ChildMenus) };
    
                foreach (var m in expanded)
                {
                    System.Diagnostics.Debug.WriteLine("Menu: " + m.Menu.MenuName);
                    foreach (var m1 in m.Descendants)
                    {
                        System.Diagnostics.Debug.WriteLine("- " + m1.MenuName);
                    }
                }
