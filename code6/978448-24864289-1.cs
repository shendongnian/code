    private void listtostringlist(List<NewsLine> lnl, List<string> myl)
    {
        for (int i = 0; i < AllNews.Count; i++)
        {
              myl.Add(AllNews[i].text);
              // etc...
        }
        for(int i = 0; i < myl.Count; i++)
        {
            myl[i] = Regex.Replace(myl[i], @"\t|\n|\r", "");
        }
    }
