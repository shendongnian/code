     for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i].Count < INTERFACES_PER_PAGE)
                {
                    pages[i].Add(interfaceToAdd);
                }
                else
                {
                    pages.Add(new List<UserInterface>());
                    pages[i + 1].Add(interfaceToAdd);
                }
            }
