    public string Update(Site site)
        {
            TextBlock block = site.Pages[0].Rows[0].BuildBlocks[0] as TextBlock;
            siteRepository.Add(site);
            return "Success";
        }
