                Params = _readonlyService.GetAll().ToList();
                if (Params.Count() != 0)
                {
                    Params.Union(SecondList);
                }
                else
                {
                    Params = SecondList;
                }
