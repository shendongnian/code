     bool NeedPartial = false;
                int i = 0;
                while (!NeedPartial && i < _Area.Count)
                {
                    if (_Area[i].Partida)
                    {
                        NeedPartial = true;
                    }
                    else
                    {
                        i++;
                    }
                    if (NeedPartial)
                    {
                        _Area[i].Partial = _Area[i].width * _Area[i].height;
                        NeedPartial = false;
                        i++;
                    }
                    else
                    {
                        NeedPartial = true;
                    }
                }
