                while (list.Count > 2)
                {
                    if (list[0].IsActive || list[list.Count - 1].IsActive)
                    {
                        list.RemoveAt(list.Count - 1);
                        list.RemoveAt(0);
                    }
                    else
                        break;
                }
