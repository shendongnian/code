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
    element[] WithStruct() {
        var t = new element[3981312];
        int z = 0;
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
                                                            t[z].a = a;
                                                            t[z].b = b;
                                                            t[z].c = c;
                                                            t[z].d = d;
                                                            t[z].e = e;
                                                            t[z].f = f;
                                                            t[z].g = g;
                                                            t[z].h = h;
                                                            t[z].i = i;
                                                            t[z].j = j;
                                                            t[z].k = k;
                                                            t[z].l = l;
                                                            t[z].m = m;
                                                            z++;
                                                        }
        return t;
    }
