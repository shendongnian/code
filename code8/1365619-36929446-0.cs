    public void tampilDenah()
    {
        for (int i = 0;i<41;i++)
        {
            arrKursi[i] = new Kursi();
            arrKursi[i].noKursi = i;
            Console.Write(arrKursi[i].noKursi);
        }
    }
