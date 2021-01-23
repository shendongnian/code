    int i = 0;
    while(File.Exists(getFileName(i)))
    {
      i+=100;
    }
    i-=90;
    while(File.Exists(getFileName(i)))
    {
      i+=10;
    }
    i-=9;
    while(File.Exists(getFileName(i)))
    {
      i+=1;
    }
