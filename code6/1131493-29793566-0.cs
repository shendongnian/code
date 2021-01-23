     struct element {
                public byte a;
                public byte b;
                public byte c;
                public byte d;
                public byte e;
                public byte f;
                public byte g;
                public byte h;
                public byte i;
                public byte j;
                public byte k;
                public byte l;
                public byte m;
            }
     element[] WithStruct(){
                var t = new element[3981312];
                for (byte a = 0; a < 2; a++)
                    for (byte b = 0; b < 3; b++)
                        for (byte c = 0; c < 4; c++)
                            for (byte d = 0; d < 3; d++)
                                for (byte e = 0; e < 4; e++)
                                    for (byte f = 0; f < 3; f++)
                                        for (byte g = 0; g < 3; g++)
                                            for (byte h = 0; h < 4; h++)
                                                for (byte i = 0; i < 2; i++)
                                                    for (byte j = 0; j < 4; j++)
                                                        for (byte k = 0; k < 4; k++)
                                                            for (byte l = 0; l < 3; l++)
                                                                for (byte m = 0; m < 4; m++)
                                                                {                                                               
                                                                    t[1].a = a;
                                                                    t[1].b = b;
                                                                    t[1].c = c;
                                                                    t[1].d = d;
                                                                    t[1].e = e;
                                                                    t[1].f = f;
                                                                    t[1].g = g;
                                                                    t[1].h = h;
                                                                    t[1].i = i;
                                                                    t[1].j = j;
                                                                    t[1].k = k;
                                                                    t[1].l = l;
                                                                    t[1].m = m;
    
                                                                }
                return t;
            }
